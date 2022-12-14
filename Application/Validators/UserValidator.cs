using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}