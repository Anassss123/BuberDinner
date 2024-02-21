using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.Users;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler( IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
             //Validate if the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalideCredentials;
            }
            //Validate the password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalideCredentials; 
            }
            //Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);;
        }
    }
}