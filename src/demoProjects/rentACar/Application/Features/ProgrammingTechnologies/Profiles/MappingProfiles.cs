using Application.Features.ProgrammingTechnologies.Dtos;
using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingTechnologies.Command.CreateProgrammingTehcnologies;
using Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnologies;
using Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnologies;
using Core.Persistence.Paging;
using Application.Features.ProgrammingTechnologies.Models;

namespace Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTehcnologies, CreatedProgrammingTechnologiesDto>().ReverseMap();
            CreateMap<ProgrammingTehcnologies, CreateProgrammingTechnologiesCommand>().ReverseMap();
            CreateMap<ProgrammingTehcnologies, UpdateProgrammingTechnologiesCommand>().ReverseMap();
            CreateMap<ProgrammingTehcnologies, UpdateProgrammingTechnologiesDto>().ReverseMap();
            CreateMap<ProgrammingTehcnologies, DeleteProgrammingTechnologiesDto>().ReverseMap();
            CreateMap<ProgrammingTehcnologies, DeleteProgrammingTechnologiesCommand>().ReverseMap();
            CreateMap<ProgrammingTehcnologies,GetListProgrammingTechnologiesDto>().ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.LanguageName)).ReverseMap();
            CreateMap<IPaginate<ProgrammingTehcnologies>, GetListProgrammingTechnologiesModel>().ReverseMap();
        }
    }
}
