using FluentValidation;
using OrgManager.Application.Features.Users.Commands.CreateUser;

namespace OrgManager.Application.Features.Users.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("نام کاربری الزامی است.")
            .NotNull()
            .MaximumLength(50).WithMessage("نام کاربری نباید بیشتر از 50 کاراکتر باشد.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("ایمیل الزامی است.")
            .NotNull()
            .EmailAddress().WithMessage("ایمیل معتبر نیست.");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("رمز عبور الزامی است.")
            .NotNull()
            .MinimumLength(6).WithMessage("رمز عبور باید حداقل 6 کاراکتر باشد.");

        RuleFor(p => p.FullName)
            .NotEmpty().WithMessage("نام کامل الزامی است.")
            .NotNull()
            .MaximumLength(100).WithMessage("نام کامل نباید بیشتر از 100 کاراکتر باشد.");
    }
}
