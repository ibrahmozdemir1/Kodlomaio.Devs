using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;


namespace Application.Features.Users.Command.UserRegisterCommand
{
    public record UserRegisterCommand(UserForRegisterDto UserForRegisterDto) : IRequest<UserLoginAndRegisterDto>
    {   
        public class classUserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserLoginAndRegisterDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly UserBusinessRules _userBusinessRules;

            public classUserRegisterCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserLoginAndRegisterDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserEmailCanNotBeDuplicated(request.UserForRegisterDto.Email);
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out var passwordHash, out var passwordSalt);

                User user = _mapper.Map<User>(request);
                user.Status = true;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                User createdUser = await _userRepository.AddAsync(user);

                AccessToken createdAccessToken = _tokenHelper.CreateToken(user, new List<OperationClaim>());

                UserLoginAndRegisterDto userRegisterDto = _mapper.Map<UserLoginAndRegisterDto>(createdAccessToken);

                return userRegisterDto;
            }
        }
    }
}
