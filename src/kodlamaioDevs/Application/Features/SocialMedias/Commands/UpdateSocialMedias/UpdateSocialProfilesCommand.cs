using Application.Features.SocialProfiles.Dtos;
using Application.Features.SocialProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.CreateSocialProfiles
{
    public class UpdateSocialMediasCommand : IRequest<UpdatedSocialMediaDto>
    {
        public int UserId { get; set; }
        public string SocialMedia { get; set; }

        public class UpdateSocialMediasCommandHandler : IRequestHandler<UpdateSocialMediasCommand, UpdatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public UpdateSocialMediasCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediasCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
