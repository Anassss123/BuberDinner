using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Users;
using ErrorOr;
using System.Runtime.ConstrainedExecution;

namespace BuberDinner.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password, DateTime createdDateTime, DateTime updatedDateTime)
        {
            //Check if user exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            //Create user (unique ID)
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                CreatedDateTime = createdDateTime,
                UpdatedDateTime = updatedDateTime
            };
            _userRepository.Add(user);
            //Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }
    }
}