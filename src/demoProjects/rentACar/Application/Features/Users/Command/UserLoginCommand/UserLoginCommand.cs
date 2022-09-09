using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Command.UserLoginCommand
{
    public record UserLoginCommand(UserForLoginDto UserForLoginDto) : IRequest<UserLoginAndRegisterDto>
    {
        public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginAndRegisterDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly UserBusinessRules _userbusinessRules;
            private readonly IMapper _mapper;

            public UserLoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, UserBusinessRules userbusinessRules, IMapper mapper)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userbusinessRules = userbusinessRules;
                _mapper = mapper;
            }

            public async Task<UserLoginAndRegisterDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                _userbusinessRules.UserShouldExistWhenRequested(user);

                _userbusinessRules.UserCredentialsShouldMatch(request.UserForLoginDto.Password, user.PasswordHash,user.PasswordSalt);

                AccessToken accessToken = _tokenHelper.CreateToken(user, new List<OperationClaim>());

                UserLoginAndRegisterDto userLoginAndRegisterDto = _mapper.Map<UserLoginAndRegisterDto>(accessToken);

                return userLoginAndRegisterDto;
            }
        }
    }
}
    

