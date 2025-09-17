using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Permissions.DeletePermission
{
    public class DeletePermissionValidator : AbstractValidator<DeletePermissionCmd>
    {
        public DeletePermissionValidator()
        {
            RuleFor(p => p.PermissionId)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .Must(p => p > 0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
