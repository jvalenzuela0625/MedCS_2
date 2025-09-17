using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.UserRoles.DeleteUserRole
{
    public class DeleteUserRoleValidator : AbstractValidator<DeleteUserRoleCmd>
    {
        public DeleteUserRoleValidator()
        {
            RuleFor(x => x.UserRoleId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
        }
    }
}
