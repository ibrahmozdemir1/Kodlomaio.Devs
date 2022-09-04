using Application.Features.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramminLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageModel>
        {
            private readonly IProgrammingLanguageRepository _programminLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgramminLanguageQueryHandler(IProgrammingLanguageRepository programminLanguageRepository, IMapper mapper)
            {
                this._programminLanguageRepository = programminLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> paginate = await _programminLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgrammingLanguageModel mapperLanguageModel = _mapper.Map<ProgrammingLanguageModel>(paginate);

                return mapperLanguageModel;
            }
        }
    }
}
