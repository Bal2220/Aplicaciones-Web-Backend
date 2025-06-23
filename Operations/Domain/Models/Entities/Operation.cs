using RetoSem10.Shared.Domain.Model.Entities;

namespace RetoSem10.Operations.Domain.Models.Entities;

public class Operation : BaseEntity
{
    public Operation() {}
    public Operation(string title, string type, DateTime date, bool status)
    {
        Title = title;
        Type = type;
        Date = date;
        Status = status;
        IsActive = true;
        CreatedDate = DateTime.Now;
    }
    
    public string Title { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public string StatusText => Status ? "Activo" : "Inactivo";
}