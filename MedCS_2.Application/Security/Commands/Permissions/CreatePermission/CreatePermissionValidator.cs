using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Permissions.CreatePermission
{
    public class CreatePermissionValidator : AbstractValidator<CreatePermissionCmd>
    {
        public CreatePermissionValidator()
        {
            RuleFor( p=> p.CreatePermissionDto.Endpoint)
                .MaximumLength(255)
                .WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters.");
            
            RuleFor(p => p.CreatePermissionDto.OperationType)
                .MaximumLength(100)
                .WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters.");

            RuleFor(p => p.CreatePermissionDto.Module)
                .MaximumLength(100)
                .WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters.");

        }
    }
}
