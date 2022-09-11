using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.UserSocialMedias.Command.CreateSocialMediaCommand
{
    public class CreateUserSocialMediaCommand : IRequest<CreateUserSocialMediaCommandDto>
    {
        public string GitHubLink { get; set; }
        public int UserId { get; set; }

        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreateUserSocialMediaCommandDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusinessRules;

            public CreateSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            }

            public async Task<CreateUserSocialMediaCommandDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaBusinessRules.UserIdCanNotBeDuplicatedInSocialMedia(request.UserId);
                UserSocialMedia userSocialMedia = _mapper.Map<UserSocialMedia>(request);
                await _userSocialMediaRepository.AddAsync(userSocialMedia);
                CreateUserSocialMediaCommandDto createSocialMediaCommandDto = _mapper.Map<CreateUserSocialMediaCommandDto>(userSocialMedia);
                return createSocialMediaCommandDto;
            }
        }
    }
}
