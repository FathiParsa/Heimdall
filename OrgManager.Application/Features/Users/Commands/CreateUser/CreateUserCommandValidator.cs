using FluentValidation;

namespace OrgManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("نام کاربری نمی‌تواند خالی باشد.")
            .NotNull()
            .MaximumLength(50).WithMessage("نام کاربری نمی‌تواند بیشتر از 50 کاراکتر باشد.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("ایمیل نمی‌تواند خالی باشد.")
            .NotNull()
            .EmailAddress().WithMessage("فرمت ایمیل نامعتبر است.");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("رمز عبور نمی‌تواند خالی باشد.")
            .NotNull()
            .MinimumLength(8).WithMessage("رمز عبور باید حداقل 8 کاراکتر باشد.");
    }
}
