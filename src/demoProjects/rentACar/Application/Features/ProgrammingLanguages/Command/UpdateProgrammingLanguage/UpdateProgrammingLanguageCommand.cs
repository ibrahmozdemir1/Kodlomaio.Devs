using Application.Features.ProgrammingLanguages.Command.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Command.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programminLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programminLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programminLanguageBusinessRules = programminLanguageBusinessRules;

            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programminLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.LanguageName);

                if (request.Id != null)
                {
                    IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.LanguageName == request.LanguageName);
                    if (result.Items.Any()) throw new BusinessException("Programming Language Name Already Exist");
                    ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                    await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                    UpdateProgrammingLanguageDto updateProgrammingLanguageDto = _mapper.Map<UpdateProgrammingLanguageDto>(programmingLanguage);
                    return updateProgrammingLanguageDto;
                }

                return null;
            }
        }
    }
}
