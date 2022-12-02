using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class GameValidator : AbstractValidator<GameDTO>
{
    public GameValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}