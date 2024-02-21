using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Users;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Common;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler( IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
             //Check if User exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            //Create User (unique ID)
            var User = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
                CreatedDateTime = command.CreatedDatetime,
                UpdatedDateTime = command.UpdatedDatetime
            };
            _userRepository.Add(User);
            //Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(User);
            return new AuthenticationResult(
                User,
                token);
        }
    }
}