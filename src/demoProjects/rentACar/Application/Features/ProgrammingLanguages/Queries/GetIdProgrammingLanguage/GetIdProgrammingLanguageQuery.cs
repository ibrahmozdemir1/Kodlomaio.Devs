using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetIdProgrammingLanguage
{
    public class GetIdProgrammingLanguageQuery : IRequest<GetIdProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class GetIdProgrammingLanguageQueryHandler : IRequestHandler<GetIdProgrammingLanguageQuery, GetIdProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<GetIdProgrammingLanguageDto> Handle(GetIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage getIdProgrammingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                if (getIdProgrammingLanguage == null) throw new BusinessException("Requested brand does not exist");
                GetIdProgrammingLanguageDto getIdProgrammingLanguageDto = _mapper.Map<GetIdProgrammingLanguageDto>(getIdProgrammingLanguage);
                return getIdProgrammingLanguageDto;
            }
        }

    }
}
