using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuberDinner.Api.Filters;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Query;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    [ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /*private readonly IAuthenticationCommandService _authenticationCommandService;
private readonly IAuthenticationQueryService _authenticationQueryService;

public AuthenticationController(IAuthenticationCommandService authenticationService,
                               IAuthenticationQueryService authenticationQueryService)
{
   _authenticationCommandService = authenticationService;
   _authenticationQueryService = authenticationQueryService;
}*/

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }
        
        public static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse (
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.User.CreatedDateTime,
                authResult.User.UpdatedDateTime,
                authResult.Token
            );
        }

    }
}