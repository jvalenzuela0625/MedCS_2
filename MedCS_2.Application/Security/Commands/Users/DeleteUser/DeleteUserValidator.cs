using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Users.DeleteUser
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCmd>
    {
        public DeleteUserValidator()
        {
            RuleFor(u => u.userId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} must be a valid non-empty GUID.");
        }
    }
}
