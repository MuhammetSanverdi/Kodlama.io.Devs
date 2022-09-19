using Application.Features.SocialMedias.Models;
using Application.Features.SocialProfiles.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia,CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, DeletedSocialMediaDto>().ReverseMap();
            CreateMap<IPaginate<SocialMedia>, SocialMediaListModel>().ReverseMap();
        }
    }
}
