using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Users;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Query
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            //Validate if the user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalideCredentials;
            }
            //Validate the password is correct
            if (user.Password !=password)
            {
                return Errors.Authentication.InvalideCredentials; 
            }
            //Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }
    }
}