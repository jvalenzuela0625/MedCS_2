using FluentValidation;

namespace MedCS_2.Application.Security.Commands.Roles.DeleteRole
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCmd>
    {
        public DeleteRoleValidator()
        {
            // Improved validation: check for positive RoleId and provide a clearer message
            RuleFor(r => r.RoleId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive, non-zero value.")
                .NotEqual(0).WithMessage("{PropertyName} must be provided");
        }
    }
}
