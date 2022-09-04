using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Command.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.LanguageName).NotEmpty();
            RuleFor(c => c.LanguageName).MinimumLength(1);
            RuleFor(c => c.LanguageName).MaximumLength(15);
        }
    }
}
