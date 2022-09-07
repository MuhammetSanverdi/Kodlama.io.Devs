using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageValdiator:AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageValdiator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
