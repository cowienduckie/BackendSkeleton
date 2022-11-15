using FluentValidation;

namespace Application.Models.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.UserName)
            .MaximumLength(50)
            .NotEmpty();
    }
}