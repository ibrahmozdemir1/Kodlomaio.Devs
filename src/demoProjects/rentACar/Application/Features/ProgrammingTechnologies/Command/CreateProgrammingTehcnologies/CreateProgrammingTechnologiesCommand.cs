using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Command.CreateProgrammingTehcnologies
{
    public class CreateProgrammingTechnologiesCommand : IRequest<CreatedProgrammingTechnologiesDto>
    {
        public string TehcnologyName { get; set; }
        public string TehcnologyDescription { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateProgrammingTechnologiesCommandHandler : IRequestHandler<CreateProgrammingTechnologiesCommand, CreatedProgrammingTechnologiesDto>
        {
            private readonly IProgrammingTechnologiesRepository _programmingTechnologiesRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologiesBusinessRules _programmingTechnologiesBusinessRules;

            public CreateProgrammingTechnologiesCommandHandler(IProgrammingTechnologiesRepository programmingTechnologiesRepository, IMapper mapper, ProgrammingTechnologiesBusinessRules programmingTechnologiesBusinessRules)
            {
                _programmingTechnologiesRepository = programmingTechnologiesRepository;
                _mapper = mapper;
                _programmingTechnologiesBusinessRules = programmingTechnologiesBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologiesDto> Handle(CreateProgrammingTechnologiesCommand request, CancellationToken cancellationToken)
            {
               // await _programmingTechnologiesBusinessRules.ProgramLanguageIDMustBeInProgrammingLanguageData(request.ProgrammingLanguageId);

                

                ProgrammingTehcnologies mapperprogrammingTechnologies = _mapper.Map<ProgrammingTehcnologies>(request);
                ProgrammingTehcnologies addprogrammingTechnologies = await _programmingTechnologiesRepository.AddAsync(mapperprogrammingTechnologies);
                CreatedProgrammingTechnologiesDto createdProgrammingTechnologiesDto = _mapper.Map<CreatedProgrammingTechnologiesDto>(addprogrammingTechnologies);
                return createdProgrammingTechnologiesDto;
            }
        }
    }
}
