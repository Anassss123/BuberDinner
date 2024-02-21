using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;

namespace BuberDinner.Api.Mapping
{
    public class AuthenticationAutoMapper : Profile
    {
        public AuthenticationAutoMapper(){
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<AuthenticationResult, AuthenticationResponse>();

        }
        
    }

}