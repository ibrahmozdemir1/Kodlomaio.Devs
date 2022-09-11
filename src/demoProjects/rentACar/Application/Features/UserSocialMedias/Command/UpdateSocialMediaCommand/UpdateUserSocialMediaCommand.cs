using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Command.UpdateSocialMediaCommand
{
    public class UpdateUserSocialMediaCommand : IRequest<UpdateUserSocialMediaCommandDto>
    {
        public int Id { get; set; }
        public string GitHubLink { get; set; }
        public int UserId { get; set; }

        public class UpdateUserSocialMediaCommandHandler : IRequestHandler<UpdateUserSocialMediaCommand, UpdateUserSocialMediaCommandDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public UpdateUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            }

            public async Task<UpdateUserSocialMediaCommandDto> Handle(UpdateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaBusinessRules.UserIdCanNotBeDuplicatedInSocialMedia(request.UserId);
                UserSocialMedia userSocialMedia = _mapper.Map<UserSocialMedia>(request);
                await _userSocialMediaRepository.UpdateAsync(userSocialMedia);
                UpdateUserSocialMediaCommandDto updateUserSocialMediaCommandDto = _mapper.Map<UpdateUserSocialMediaCommandDto>(userSocialMedia);
                return updateUserSocialMediaCommandDto;
            }
        }

    }
}
