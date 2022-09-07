using Application.Features.ProgramingLanguages.Rules;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand:IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateProgrammingLanguageHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public UpdateProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules businessRules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _businessRules = businessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.IsExits(request.Name);
                
                var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                var updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
                var programmingLanguageDto= _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);
                return programmingLanguageDto;
            }
        }

    }
}
