using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class HeroValidator : AbstractValidator<HeroDTO>
{
    public HeroValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}