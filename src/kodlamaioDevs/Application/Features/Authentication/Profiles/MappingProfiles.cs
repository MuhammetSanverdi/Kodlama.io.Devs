using Application.Features.Authentication.Dtos;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisteredUserDto>().ReverseMap();
            CreateMap<User, LoginedUserDto>().ReverseMap();
        }
    }
}
