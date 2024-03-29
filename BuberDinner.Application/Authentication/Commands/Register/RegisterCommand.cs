using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public record RegisterCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password,
        DateTime CreatedDatetime,
        DateTime UpdatedDatetime
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}