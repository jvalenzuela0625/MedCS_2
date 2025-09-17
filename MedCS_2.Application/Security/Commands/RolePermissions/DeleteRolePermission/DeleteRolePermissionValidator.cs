using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.RolePermissions.DeleteRolePermission
{
    public class DeleteRolePermissionValidator: AbstractValidator<DeleteRolePermissionCmd>
    {
        public DeleteRolePermissionValidator()
        {
            RuleFor(rp => rp.RolePermissionId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(rp => rp > 0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
