using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                where TRequest : IRequest<TResponse>
                where TResponse : IErrorOr
    {
        /*public async Task<AuthenticationResult> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<AuthenticationResult> next)
        {
            var result = await next();
            return result;
        }*/
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
            )
        {
            if (_validator is null)
            {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors
                        .Select(ValidationFailure => Error.Validation(ValidationFailure.PropertyName , ValidationFailure.ErrorMessage))
                        .ToList();
            return (dynamic)errors;
        }
    }
}