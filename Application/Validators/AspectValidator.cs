using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class AspectValidator : AbstractValidator<AspectDTO>
{
    public AspectValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}