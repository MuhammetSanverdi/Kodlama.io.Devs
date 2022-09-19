using Core.Security.Dtos;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.Register
{
    public class RegisterValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).MinimumLength(2);
        }
    }
}
