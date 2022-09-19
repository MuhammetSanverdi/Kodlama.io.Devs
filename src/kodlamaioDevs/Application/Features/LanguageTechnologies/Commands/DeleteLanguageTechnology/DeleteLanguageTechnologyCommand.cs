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

namespace Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand : IRequest<DeletedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public DeleteLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var mappedTechnology = _mapper.Map<LanguageTechnology>(request);
                var deletedTecnology = await _languageTechnologyRepository.DeleteAsync(mappedTechnology);
                var mappedTechnologyDto = _mapper.Map<DeletedLanguageTechnologyDto>(deletedTecnology);
                return mappedTechnologyDto;
            }
        }
    }
}
