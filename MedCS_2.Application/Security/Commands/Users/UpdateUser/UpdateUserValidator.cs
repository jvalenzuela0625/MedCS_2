using FluentValidation;

namespace MedCS_2.Application.Security.Commands.Users.UpdateUser
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserCmd>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.updateUserDto.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(u => u.updateUserDto.Email)                
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Matches("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,4})+)$").WithMessage("{PropertyName} entered is invalid")
                .MinimumLength(5).WithMessage("{PropertyName} cannot be less than {MinLength} characters.")
                .MaximumLength(320).WithMessage("{PropertyName} cannot exceed more than {MaxLength} characters.");

            RuleFor(u => u.updateUserDto.FirstName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(u => u.updateUserDto.LastName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");

            RuleFor(u => u.updateUserDto.JobTitle)
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.")
                .When(u => !string.IsNullOrWhiteSpace(u.updateUserDto.JobTitle));

            RuleFor(u => u.updateUserDto.Role)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed {MaxLength} characters.");
        }
    }
}
