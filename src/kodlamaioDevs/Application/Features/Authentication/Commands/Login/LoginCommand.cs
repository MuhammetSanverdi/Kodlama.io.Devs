using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.Login
{
    public class LoginCommand: UserForLoginDto,IRequest<LoginedUserDto>
    {
        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<LoginedUserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var userExist= _authBusinessRules.IsExists(request.Email);
                if (!userExist.Result)
                {
                    throw new BusinessException("User is not exists");
                }

                var user = _userRepository.GetAsync(u => u.Email == request.Email).Result;
                bool verifiedUser = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
                if (!verifiedUser)
                {
                    throw new BusinessException("Password Invaild");
                }

                var mappedUser = _mapper.Map<LoginedUserDto>(user);
                var userClaims = _userRepository.GetOperationClaims(user);
                AccessToken accessToken = _tokenHelper.CreateToken(user, userClaims);
                mappedUser.AccessToken = accessToken.Token;

                return mappedUser;




            }
        }
    }
}
