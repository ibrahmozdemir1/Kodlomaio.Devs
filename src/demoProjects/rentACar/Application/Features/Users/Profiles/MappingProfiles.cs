using Application.Features.Users.Command.UserRegisterCommand;
using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserRegisterCommand, UserApplication>()
                .ForMember(u => u.Email, c => c.MapFrom(e => e.UserForRegisterDto.Email))
                .ForMember(u => u.FirstName, c => c.MapFrom(e => e.UserForRegisterDto.FirstName))
                .ForMember(u => u.LastName, c => c.MapFrom(e => e.UserForRegisterDto.LastName))
                .ReverseMap();
            CreateMap<UserLoginAndRegisterDto, AccessToken>()
                .ForMember(u => u.Token, c => c.MapFrom(t => t.AccessToken.Token))
                .ForMember(u => u.Expiration, c => c.MapFrom(t => t.AccessToken.Expiration))
                .ReverseMap();
        }
    }
}
