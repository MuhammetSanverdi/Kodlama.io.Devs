using Application.Features.SocialMedias.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Queries.GetListSocialMedias
{
    public class GetListSocialMediasQuery : IRequest<SocialMediaListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListSocialMediaQueryHandler : IRequestHandler<GetListSocialMediasQuery, SocialMediaListModel>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public GetListSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaListModel> Handle(GetListSocialMediasQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMedia> socialMedias = await _socialMediaRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                SocialMediaListModel mappedSocialMedias = _mapper.Map<SocialMediaListModel>(socialMedias);
                return mappedSocialMedias;
            }
        }
    }
}
