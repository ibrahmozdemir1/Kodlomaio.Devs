using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Command.CreateProgrammingTehcnologies
{
    public class CreateProgrammingTechnologiesCommandValidator : AbstractValidator<CreateProgrammingTechnologiesCommand>
    {
        public CreateProgrammingTechnologiesCommandValidator()
        {
            RuleFor(p =>p.TehcnologyName).NotEmpty();
            RuleFor(p =>p.ProgrammingLanguageId).NotEmpty();
            RuleFor(p => p.TehcnologyDescription).NotEmpty();
            RuleFor(p => p.TehcnologyDescription).MaximumLength(50);

        }
    }
}
