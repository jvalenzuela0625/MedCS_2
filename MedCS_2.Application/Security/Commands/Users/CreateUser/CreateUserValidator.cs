using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Users.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCmd>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.User.Email)
                .MinimumLength(5).WithMessage("{PropertyName} cannot be less than {MinLength} characters.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .Matches("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,4})+)$").WithMessage("email entered is invalid")
                .MaximumLength(320).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters.");

            RuleFor(u => u.User.FirstName)
               .MaximumLength(255).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters");

            RuleFor(u => u.User.LastName)
                .MaximumLength(255).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters");

            RuleFor(u => u.User.Role)
                .MaximumLength(255).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters");

            RuleFor(u => u.User.JobTitle)
                .MaximumLength(255).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters");

            RuleFor(u => u.User.Role)
                .MaximumLength(255).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters");

            RuleFor(u => u.User.Password)
                .MaximumLength(256).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters");

        }
    }
}
