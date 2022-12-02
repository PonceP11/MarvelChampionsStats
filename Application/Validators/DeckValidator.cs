using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class DeckValidator : AbstractValidator<DeckDTO>
{
    public DeckValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}