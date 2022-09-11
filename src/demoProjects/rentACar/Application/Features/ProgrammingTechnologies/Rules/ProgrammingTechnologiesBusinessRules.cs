using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologiesBusinessRules
    {
        private readonly IProgrammingTechnologiesRepository _programmingTechnologiesRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public async Task ProgramLanguageIDMustBeInProgrammingLanguageData(int id)
        {
            _programmingLanguageBusinessRules.ProgrammingLanguageIDCannotBeDuplicated(id);
        }
    }
}
