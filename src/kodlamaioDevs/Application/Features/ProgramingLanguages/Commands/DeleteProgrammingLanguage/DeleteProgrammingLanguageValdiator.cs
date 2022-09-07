using Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageValdiator:AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageValdiator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
