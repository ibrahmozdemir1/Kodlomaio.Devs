using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Command.UserRegisterCommand
{
    public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterCommandValidator()
        {
            RuleFor(c => c.UserForRegisterDto.Email).EmailAddress().WithMessage("A valid email is required")
                .NotEmpty().WithMessage("Email address is required");
            RuleFor(c => c.UserForRegisterDto.Password).NotEmpty().WithMessage("Password is not empty");
            RuleFor(c => c.UserForRegisterDto.FirstName).NotEmpty().WithMessage("First Name is not empty");
            RuleFor(c => c.UserForRegisterDto.LastName).NotEmpty().WithMessage("Last Name is not empty");
        }

    }
}
