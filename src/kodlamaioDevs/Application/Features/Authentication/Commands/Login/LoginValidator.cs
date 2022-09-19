using Core.Security.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.Login
{
    public class LoginValidator:AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Email).EmailAddress();
        }
    }
}
