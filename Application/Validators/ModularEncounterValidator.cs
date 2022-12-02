using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class ModularEncounterValidator : AbstractValidator<ModularEncounterDTO>
{
    public ModularEncounterValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}