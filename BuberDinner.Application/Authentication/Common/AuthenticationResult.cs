using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Users;

namespace BuberDinner.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User, string Token
    );
}