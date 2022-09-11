using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Command.CreateSocialMediaCommand
{
    public class CreateUserSocialMediaCommandValidator : AbstractValidator<CreateUserSocialMediaCommand>
    {
        public CreateUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID can not be empty");
            RuleFor(x => x.GitHubLink).NotEmpty().WithMessage("Social Media Link can not be empty");
        }
    }
}
