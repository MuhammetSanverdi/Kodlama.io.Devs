using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task IsExits(string name)
        {
            ProgrammingLanguage result = await _programmingLanguageRepository.GetAsync(p => p.Name == name);
            if (result != null)
                throw new BusinessException("The name is exists");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage is null) throw new BusinessException("Requested programming language does not exists");
        }
    }
}
