using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnoloy;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, LanguageTechnologyListDto>().ForMember(c=>c.LanguageName,opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();
        }
    }
}
