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

namespace Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnologies
{
    public class UpdateProgrammingTechnologiesCommand : IRequest<UpdateProgrammingTechnologiesDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string TehcnologyName { get; set; }
        public string TehcnologyDescription { get; set; }

        public class UpdateProgrammingTechnologiesCommandHandler : IRequestHandler<UpdateProgrammingTechnologiesCommand, UpdateProgrammingTechnologiesDto>
        {
            private readonly IProgrammingTechnologiesRepository _programmingTechnologiesRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologiesBusinessRules _programmingTechnologiesBusinessRules;

            public UpdateProgrammingTechnologiesCommandHandler(IProgrammingTechnologiesRepository programmingTechnologiesRepository, IMapper mapper, ProgrammingTechnologiesBusinessRules programmingTechnologiesBusinessRules)
            {
                _programmingTechnologiesRepository = programmingTechnologiesRepository;
                _mapper = mapper;
                _programmingTechnologiesBusinessRules = programmingTechnologiesBusinessRules;
            }

            public async Task<UpdateProgrammingTechnologiesDto> Handle(UpdateProgrammingTechnologiesCommand request, CancellationToken cancellationToken)
            {
                //await _programmingTechnologiesBusinessRules.ProgramLanguageIDMustBeInProgrammingLanguageData(request.ProgrammingLanguageId);
                if(request.Id != null)
                {
                    ProgrammingTehcnologies mapperprogrammingTechnologies = _mapper.Map<ProgrammingTehcnologies>(request);
                    await _programmingTechnologiesRepository.UpdateAsync(mapperprogrammingTechnologies);
                    UpdateProgrammingTechnologiesDto updateProgrammingTechnologiesDto = _mapper.Map<UpdateProgrammingTechnologiesDto>(mapperprogrammingTechnologies);
                    return updateProgrammingTechnologiesDto;
                }

                return null;
            }
        }

    }
}
