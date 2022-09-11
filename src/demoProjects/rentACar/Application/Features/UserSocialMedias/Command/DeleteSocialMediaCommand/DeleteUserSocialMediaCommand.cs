using Application.Features.UserSocialMedias.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Command.DeleteSocialMediaCommand
{
    public class DeleteUserSocialMediaCommand : IRequest<DeleteUserSocialMediaCommandDto>
    {
        public int UserId { get; set; }
        public int Id { get; set; }

        public class DeleteUserSocialMediaCommandHandler : IRequestHandler<DeleteUserSocialMediaCommand, DeleteUserSocialMediaCommandDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            public async Task<DeleteUserSocialMediaCommandDto> Handle(DeleteUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                UserSocialMedia userSocialMedia = _mapper.Map<UserSocialMedia>(request);
                await _userSocialMediaRepository.DeleteAsync(userSocialMedia);
                DeleteUserSocialMediaCommandDto  deleteUserSocialMediaCommandDto = _mapper.Map<DeleteUserSocialMediaCommandDto>(userSocialMedia);
                return deleteUserSocialMediaCommandDto;
            }
        }


    }
}
