using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Queries.Users.GetUserById
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(u => u.UserId)
                .NotEqual(Guid.Empty).WithMessage("User ID must be provided.");
        }
    }
}
