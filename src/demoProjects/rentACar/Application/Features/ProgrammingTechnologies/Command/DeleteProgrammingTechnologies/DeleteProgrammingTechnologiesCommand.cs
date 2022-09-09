using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnologies
{
    public class DeleteProgrammingTechnologiesCommand : IRequest<DeleteProgrammingTechnologiesDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingTechnologiesCommandHandler : IRequestHandler<DeleteProgrammingTechnologiesCommand, DeleteProgrammingTechnologiesDto>
        {
            private readonly IProgrammingTechnologiesRepository _programmingTechnologiesRepository;
            private readonly IMapper _mapper;

            public DeleteProgrammingTechnologiesCommandHandler(IProgrammingTechnologiesRepository programmingTechnologiesRepository, IMapper mapper)
            {
                _programmingTechnologiesRepository = programmingTechnologiesRepository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingTechnologiesDto> Handle(DeleteProgrammingTechnologiesCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTehcnologies programmingTechnologies = _mapper.Map<ProgrammingTehcnologies>(request);
                await _programmingTechnologiesRepository.DeleteAsync(programmingTechnologies);
                DeleteProgrammingTechnologiesDto deleteProgrammingTechnologiesDto = _mapper.Map<DeleteProgrammingTechnologiesDto>(programmingTechnologies);
                return deleteProgrammingTechnologiesDto;
            }
        }

    }
}
