using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.CreateProgrammingLanguage
{
    public class UpdateProgrammingLanguageValdiator:AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageValdiator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
