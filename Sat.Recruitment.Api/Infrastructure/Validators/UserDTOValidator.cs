using FluentValidation;
using Sat.Recruitment.Api.Domain.DTOs;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Infrastructure.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {

            var userTypes = new List<string>() { "Premium", "SuperUser", "Normal" };

            RuleFor(x => x.Phone).NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(10).MaximumLength(15);
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required").EmailAddress();
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(7).MaximumLength(50);
            RuleFor(x => x.UserType).Must(x => userTypes.Contains(x)).WithMessage("Please only use: " + string.Join(",", userTypes));

        }
    }
}
