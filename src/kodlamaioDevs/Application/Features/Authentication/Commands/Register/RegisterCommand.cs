using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http.Features.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.Register
{
    public class RegisterCommand : UserForRegisterDto,IRequest<RegisteredUserDto>
    {
        public class RegisterCommandHamdler : IRequestHandler<RegisterCommand, RegisteredUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;
            private ITokenHelper _tokenHelper;
            public RegisterCommandHamdler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
                _tokenHelper = tokenHelper;
            }
            public async Task<RegisteredUserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;

                var rules = _authBusinessRules.IsExists(request.Email);
                if (rules.Result)
                {
                    throw new BusinessException("Email is exist");
                }
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                var newUser = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Status = true,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    AuthenticatorType = 0
                };
                var addedUser = await _userRepository.AddAsync(newUser);
                var mappedUser = _mapper.Map<RegisteredUserDto>(addedUser);
                var userClaims = _userRepository.GetOperationClaims(newUser);
                AccessToken accessToken = _tokenHelper.CreateToken(newUser, userClaims);
                mappedUser.AccessToken = accessToken.Token;
                
                return mappedUser;
            }
        }
    }
}
