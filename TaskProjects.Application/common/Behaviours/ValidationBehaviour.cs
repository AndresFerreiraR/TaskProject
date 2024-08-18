using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using TaskProjects.Application.common.Exceptions;
using TaskProjects.Commons.Errors;

namespace TaskProjects.Application.common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.Where(r => r.Errors.Any())
                                               .SelectMany(r => r.Errors)
                                               .Select(r => new BaseError() { PropertyMassage = r.PropertyName, ErrorMessage = r.ErrorMessage })
                                               .ToList();

                if(failures.Any())
                {
                    throw new ValidationExceptionCustom(failures);
                }
            }

            return await next();
        }
    }
}