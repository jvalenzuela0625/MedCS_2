using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.UserRoles.CreateUserRole
{
    public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCmd>
    {
        public CreateUserRoleValidator()
        {
            RuleFor(u => u.CreateUsrRoleDto.UserId)
               .NotEmpty().WithMessage("User Id is required. ")
               .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID."); ;

            RuleFor(u => u.CreateUsrRoleDto.RoleId)
               .NotEmpty().WithMessage("Role Id is required.")
               .Must(roleID => roleID > 0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
