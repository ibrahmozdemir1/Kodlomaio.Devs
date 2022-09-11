using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            this._programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageIDCannotBeDuplicated(int id)
        {
            ProgrammingLanguage result = await _programmingLanguageRepository.GetAsync(p => p.Id == id);
            if (result == null) throw new BusinessException("Programming Language ID Not be empty.");
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.LanguageName == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language name exists.");
        }
    }
}
