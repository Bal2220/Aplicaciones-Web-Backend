using FluentValidation;
using RetoSem11.Management.Domain.Models.Commands;

namespace RetoSem11.Management.Domain.Models.Validators;

public class CreateOperationCommandValidator : AbstractValidator<CreateOperationCommand>
{
    public CreateOperationCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("El titulo no puede estar vacio.")
            .Length(3, 100).WithMessage("El titulo debe ser entre 3 y 100 caracteres.");
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("La descripción no puede estar vacio.");
        RuleFor(c => c.Description)
            .MaximumLength(250).WithMessage("La descripción no puede ser de más de 250 caracteres.");
        RuleFor(c => c.Type)
            .IsInEnum().WithMessage("El tipo debe ser uno de los siguientes: Excavation, Transport o Maintenance.");
        RuleFor(c => c.Date)
            .NotEmpty().WithMessage("La fecha no puede estar vacia.")
            .LessThan(DateTime.Now).WithMessage("La fecha no puede ser futura.");
    }
}