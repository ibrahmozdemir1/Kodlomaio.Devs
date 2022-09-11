using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.UserSocialMedias.Command.CreateSocialMediaCommand;
using Application.Features.UserSocialMedias.Command.DeleteSocialMediaCommand;
using Application.Features.UserSocialMedias.Command.UpdateSocialMediaCommand;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Models;
using Application.Features.UserSocialMedias.Queries.GetListUserSocialMedia;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, CreateUserSocialMediaCommandDto>().ReverseMap();
            CreateMap<UserSocialMedia, DeleteUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, DeleteUserSocialMediaCommandDto>().ReverseMap();
            CreateMap<UserSocialMedia, UpdateUserSocialMediaCommandDto>().ReverseMap();
            CreateMap<UserSocialMedia, UpdateUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, GetListUserSocialMediaDto>().ForMember(c => c.UserId, opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<IPaginate<UserSocialMedia>, GetListUserSocialMediaModel>().ReverseMap();
        }
    }
}
