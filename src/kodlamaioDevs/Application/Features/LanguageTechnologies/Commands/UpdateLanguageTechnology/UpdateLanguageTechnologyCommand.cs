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

namespace Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommand : IRequest<UpdatedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand, UpdatedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public UpdateLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<UpdatedLanguageTechnologyDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var mappedTechnology = _mapper.Map<LanguageTechnology>(request);
                var updatedTecnology = await _languageTechnologyRepository.UpdateAsync(mappedTechnology);
                var mappedTechnologyDto = _mapper.Map<UpdatedLanguageTechnologyDto>(updatedTecnology);
                return mappedTechnologyDto;
            }
        }
    }
}
