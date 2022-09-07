using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery:IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public GetByIdProgrammingLanguageQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules businessRules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _businessRules = businessRules;
            }

            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                _businessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
                var programmingLanguageDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
                return programmingLanguageDto;
            }
        }
    }
}
