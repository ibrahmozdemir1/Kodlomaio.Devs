using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Command.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgramminLanguageDto>
    {
        public string LanguageName { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgramminLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramminLanguageBusinessRules _programminLanguageBusinessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgramminLanguageBusinessRules programminLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programminLanguageBusinessRules = programminLanguageBusinessRules;
            }

            public async Task<CreatedProgramminLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programminLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.LanguageName);


                ProgrammingLanguage mapperProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mapperProgrammingLanguage);
                CreatedProgramminLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgramminLanguageDto>(createProgrammingLanguage);

                return createdProgrammingLanguageDto;
            }
        }
    }
}
