using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Command.UpdateSocialMediaCommand
{
    public class UpdateUserSocialMediaCommandValidator : AbstractValidator<UpdateUserSocialMediaCommand>
    {
        public UpdateUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID not be empty");
            RuleFor(x => x.GitHubLink)
                .NotEmpty()
                .WithMessage("Link is not be empty");
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID not be empty");
        }
    }
}
