using FluentValidation;
using Medical.Application.Features.Treatment.Commands.AddTreatment;

namespace Medical.Application.Validations.TreatmentValidators;

public class AddTreatmentValidator : AbstractValidator<AddTreatmentCommandRequest>
{
    public AddTreatmentValidator()
    {
        RuleFor(d => d.treatment.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("{ProperyName} must not be empty!")
            .Length(2, 50)
            .WithMessage("{ProperyName} must be between 2 and 50 characters!");
    }
}
