using FluentValidation;
using MeetupTime.API.Entities;
using MeetupTime.API.Models;

namespace MeetupTime.API.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator(Context context)
    {
        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(x => x.Password)
            .Equal(x => x.ConfirmPassword);

        RuleFor(x => x.Email).Custom((value, errorsContext) =>
        {
            if (context.Users.Any(u => u.Email == value))
            {
                errorsContext.AddFailure("Email", "That email address is taken");
            }
        });
    }
}
