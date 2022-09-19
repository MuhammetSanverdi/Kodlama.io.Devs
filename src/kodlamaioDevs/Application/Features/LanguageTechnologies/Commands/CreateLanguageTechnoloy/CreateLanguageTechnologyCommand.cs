using Application.Features.LanguageTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnoloy
{
    public class CreateLanguageTechnologyCommand:IRequest<CreatedLanguageTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand, CreatedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public CreateLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var mappedTechnology = _mapper.Map<LanguageTechnology>(request);
                var createdTecnology = await _languageTechnologyRepository.AddAsync(mappedTechnology);
                var mappedTechnologyDto = _mapper.Map<CreatedLanguageTechnologyDto>(createdTecnology);
                return mappedTechnologyDto;
            }
        }
    }
}
