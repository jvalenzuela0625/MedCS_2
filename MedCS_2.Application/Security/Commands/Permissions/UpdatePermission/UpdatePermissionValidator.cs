using FluentValidation;

namespace MedCS_2.Application.Security.Commands.Permissions.UpdatePermission
{
    public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionCmd>
    {
        public UpdatePermissionValidator()
        {
            RuleFor(r => r.UpdatePermissionDto.Id)
                  .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(r => r.UpdatePermissionDto.Module)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(r => r.UpdatePermissionDto.OperationType)
                  .NotEmpty().WithMessage("Operation type is required.")
                  .MaximumLength(50).WithMessage("Operation type must not exceed 50 characters.");

            RuleFor(r => r.UpdatePermissionDto.Endpoint)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}
