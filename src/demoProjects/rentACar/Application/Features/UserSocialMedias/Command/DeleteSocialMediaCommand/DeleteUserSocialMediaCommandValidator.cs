using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Command.DeleteSocialMediaCommand
{
    public class DeleteUserSocialMediaCommandValidator : AbstractValidator<DeleteUserSocialMediaCommand>
    {
        public DeleteUserSocialMediaCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID not be empty.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID not be empty.");
        }
    }
}
