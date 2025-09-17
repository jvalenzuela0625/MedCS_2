using FluentValidation;
using MedCS_2.Application.Security.Commands.Roles.DeleteRole;
using MedCS_2.Application.Security.Commands.Users.DeleteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Roles.CreateRole
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCmd>
    {
        public CreateRoleValidator()
        {
            RuleFor(r => r.role.Name)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters");
        }
    }
}
