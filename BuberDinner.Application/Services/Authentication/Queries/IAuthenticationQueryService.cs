using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Query
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}