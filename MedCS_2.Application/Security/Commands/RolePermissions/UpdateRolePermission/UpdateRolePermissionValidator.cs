using FluentValidation;

namespace MedCS_2.Application.Security.Commands.RolePermissions.UpdateRolePermission
{
    public class UpdateRolePermissionValidator : AbstractValidator<UpdateRolePermissionCmd>
    {

        public UpdateRolePermissionValidator()
        {
            RuleFor(x => x.RolePermissionDto)
                .NotNull().WithMessage("RolePermissionDto is required.");

            RuleFor(x => x.RolePermissionDto.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.RolePermissionDto.PermissionId)
                .GreaterThan(0).WithMessage("PermissionId must be greater than 0.");

            RuleFor(x => x.RolePermissionDto.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0.");
        }
        
    }
}
