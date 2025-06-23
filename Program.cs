using Microsoft.EntityFrameworkCore;
using RetoSem9.Catalog.Application.CommandServices;
using RetoSem9.Catalog.Application.QueryServices;
using RetoSem9.Catalog.Domain;
using RetoSem9.Catalog.Domain.Services;
using RetoSem9.Catalog.Infraestructure;
using RetoSem9.Shared.Domain.Repositories;
using RetoSem9.Shared.Infraestructure.Persistence.Configuration;
using RetoSem9.Shared.Infraestructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Verify Database Connection String
if (connectionString is null)
    // Stop the application if the connection string is not set.
    throw new Exception("Database connection string is not set.");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<CenterContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<CenterContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });


// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDiscountQueryServices, DiscountQueryServices>();
builder.Services.AddScoped<IDiscountCommandServices, DiscountCommandServices>();


var app = builder.Build();


// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CenterContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();