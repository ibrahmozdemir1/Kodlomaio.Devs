using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnologies
{
    public class UpdateProgrammingTechnologiesCommandValidator : AbstractValidator<UpdateProgrammingTechnologiesCommand>
    {
        public UpdateProgrammingTechnologiesCommandValidator()
        {
            RuleFor(p => p.ProgrammingLanguageId).NotNull();
            RuleFor(p => p.TehcnologyName).NotNull();
            RuleFor(p => p.TehcnologyDescription).NotNull();
            RuleFor(p => p.TehcnologyDescription).MaximumLength(50);
        }
    }
}
