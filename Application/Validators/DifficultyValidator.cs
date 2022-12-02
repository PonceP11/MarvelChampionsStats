using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class DifficultyValidator : AbstractValidator<DifficultyDTO>
{
    public DifficultyValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}