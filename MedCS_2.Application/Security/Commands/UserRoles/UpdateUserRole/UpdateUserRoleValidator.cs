using FluentValidation;

namespace MedCS_2.Application.Security.Commands.UserRoles.UpdateUserRole
{
    public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleCmd>
    {
        public UpdateUserRoleValidator()
        {
            RuleFor(u => u.UserRoleDto.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");

            RuleFor(u => u.UserRoleDto.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");

            RuleFor(u => u.UserRoleDto.RoleId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive integer.");
        }
    }
}
