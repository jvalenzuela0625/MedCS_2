using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.RolePermissions.CreateRolePermission
{
    public class CreateRolePermissionValidator : AbstractValidator<CreateRolePermissionCmd>
    {
        public CreateRolePermissionValidator()
        {
            RuleFor(rp => rp.CreateRolePermissionDTO)
                .NotNull().WithMessage("CreateRolePermissionDTO cannot be null");

            RuleFor(rp => rp.CreateRolePermissionDTO.PermissionId)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(rp => rp.CreateRolePermissionDTO.RoleId)
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
