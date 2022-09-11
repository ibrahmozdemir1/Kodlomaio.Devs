using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.UserSocialMedias.Models;
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

namespace Application.Features.UserSocialMedias.Queries.GetListUserSocialMedia
{
    public class GetListUserSocialMediaQuery : IRequest<GetListUserSocialMediaModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserSocialMediaQueryHandler : IRequestHandler<GetListUserSocialMediaQuery, GetListUserSocialMediaModel>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;

            public GetListUserSocialMediaQueryHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper _mapper)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                this._mapper = _mapper;
            }

            public async Task<GetListUserSocialMediaModel> Handle(GetListUserSocialMediaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserSocialMedia> userSocialMedia = await
                    _userSocialMediaRepository.GetListAsync(include: p => p.Include(m => m.User),
                                                            index: request.PageRequest.Page,
                                                            size: request.PageRequest.PageSize,
                                                            enableTracking: false,
                            cancellationToken: cancellationToken);
                GetListUserSocialMediaModel getListUserSocialMediaModel = _mapper.Map<GetListUserSocialMediaModel>(userSocialMedia);
                return getListUserSocialMediaModel;
            }
        }

    }
}
