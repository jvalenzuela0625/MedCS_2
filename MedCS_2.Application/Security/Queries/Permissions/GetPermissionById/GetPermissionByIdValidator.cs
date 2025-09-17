using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Queries.Permissions.GetPermissionById
{
    public class GetPermissionByIdValidator : AbstractValidator<GetPermissionByIdQuery>
    {
        public GetPermissionByIdValidator()
        {
            RuleFor(r => r.PermissionId)
                .NotEqual(0)
                .WithMessage("Permission ID must be provided.");
        }
    }
}
