using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Command.DeleteProgrammingLangue
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLangueageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLangueageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingLangueageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                if(request.Id != null)
                {
                    ProgrammingLanguage result = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                    if(result != null)
                    {
                        ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(result);
                        await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
                        DeleteProgrammingLangueageDto deleteProgrammingLanguageDto = _mapper.Map<DeleteProgrammingLangueageDto>(programmingLanguage);
                        return deleteProgrammingLanguageDto;
                    }
                }
                return null;
            }
        }

    }
}
