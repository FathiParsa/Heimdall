using FluentValidation;
using OrgManager.Application.Features.Users.Commands.UpdateUser;

namespace OrgManager.Application.Features.Users.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("شناسه کاربر الزامی است.")
            .NotNull();

        RuleFor(p => p.FullName)
            .NotEmpty().WithMessage("نام کامل الزامی است.")
            .NotNull()
            .MaximumLength(100).WithMessage("نام کامل نباید بیشتر از 100 کاراکتر باشد.");
    }
}
