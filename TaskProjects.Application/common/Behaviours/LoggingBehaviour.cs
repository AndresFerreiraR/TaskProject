using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TaskProjects.Application.common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CleanArchitecture Request Handling: {typeof(TRequest).Name} {JsonSerializer.Serialize(request)}");
            var response = await next();
            _logger.LogInformation($"CleanArchitecture Response Handling: {typeof(TRequest).Name} {JsonSerializer.Serialize(response)}");

            return response;
        }
    }
}