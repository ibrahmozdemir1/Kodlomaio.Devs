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

        public async Task ProgramLanguageIDMustBeInProgrammingLanguageData(int id)
        {
            //ProgrammingTehcnologies result = await _programmingTechnologiesRepository.GetListAsync(include: p => p.Include(c => c.ProgrammingLanguage),p => p.FirstOrDefault(c => c.ProgrammingLanguageId == id));
            //if (result != null) throw new BusinessException("Programming Language Id Must Be In Database");
        }
    }
}
