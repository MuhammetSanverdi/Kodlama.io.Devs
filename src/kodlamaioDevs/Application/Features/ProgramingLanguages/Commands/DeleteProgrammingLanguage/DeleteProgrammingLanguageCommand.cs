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
    public class DeleteProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class DeleteProgrammingLanguageHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

            public DeleteProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                var deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedProgrammingLanguage);
                var programmingLanguageDto= _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
                return programmingLanguageDto;
            }
        }

    }
}
