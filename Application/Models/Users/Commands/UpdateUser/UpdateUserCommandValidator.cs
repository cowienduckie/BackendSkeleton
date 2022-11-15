using FluentValidation;

namespace Application.Models.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(v=>v.FirstName)
            .MaximumLength(50)
            .NotEmpty();
    }
}