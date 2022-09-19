using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Rules
{
    public class AuthBusinessRules
    {
        IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsExists(string email)
        {
            var existUser = await _userRepository.GetAsync(u => u.Email == email);
            if (existUser==null)
            {
                return false;

            }
            return true;
        }
    }
}
