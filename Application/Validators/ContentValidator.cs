using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class ContentValidator : AbstractValidator<ContentDTO>
{
    public ContentValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}