using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Roles.UpdateRole
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleCmd>
    {
        public UpdateRoleValidator()
        {
            RuleFor(r => r.UpdateRoleDto.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            RuleFor(r => r.UpdateRoleDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
    }
}
