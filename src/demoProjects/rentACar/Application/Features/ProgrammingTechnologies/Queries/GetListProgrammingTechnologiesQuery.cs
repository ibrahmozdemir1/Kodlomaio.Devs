using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Queries
{
    public class GetListProgrammingTechnologiesQuery : IRequest<GetListProgrammingTechnologiesModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologiesQueryHandler : IRequestHandler<GetListProgrammingTechnologiesQuery, GetListProgrammingTechnologiesModel>
        {
            private readonly IProgrammingTechnologiesRepository _programmingTechnologiesRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologiesQueryHandler(IProgrammingTechnologiesRepository programmingTechnologiesRepository, IMapper mapper)
            {
                _programmingTechnologiesRepository = programmingTechnologiesRepository;
                _mapper = mapper;
            }

            public async Task<GetListProgrammingTechnologiesModel> Handle(GetListProgrammingTechnologiesQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTehcnologies> programmingTechnologies = await
                    _programmingTechnologiesRepository.GetListAsync(include: m => m.Include(c => c.ProgrammingLanguage),
                                                                    index: request.PageRequest.Page,
                                                                    size: request.PageRequest.PageSize);
                GetListProgrammingTechnologiesModel getListProgrammingTechnologiesModel = _mapper.Map<GetListProgrammingTechnologiesModel>(programmingTechnologies);
                return getListProgrammingTechnologiesModel;
            }
        }
    }
}
