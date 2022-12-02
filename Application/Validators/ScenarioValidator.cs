using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class ScenarioValidator : AbstractValidator<ScenarioDTO>
{
    public ScenarioValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}