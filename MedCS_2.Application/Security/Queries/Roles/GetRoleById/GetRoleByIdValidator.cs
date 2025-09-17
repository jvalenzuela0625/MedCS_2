using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Queries.Roles.GetRoleById
{
    public class GetRoleByIdValidator : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdValidator()
        {
            RuleFor(r => r.RoleId)
                .NotEqual(0)
                .WithMessage("Role ID must be provided.");
        }
    }
}
