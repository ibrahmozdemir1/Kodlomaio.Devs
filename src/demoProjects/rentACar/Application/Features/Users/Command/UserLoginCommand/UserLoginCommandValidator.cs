using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Command.UserLoginCommand
{
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(u => u.UserForLoginDto.Email).NotEmpty().WithMessage("E-mail is not empty");
            RuleFor(u => u.UserForLoginDto.Password).NotEmpty().WithMessage("E-mail is not empty");
        }
    }
}
