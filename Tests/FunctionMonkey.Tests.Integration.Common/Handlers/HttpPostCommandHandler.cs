﻿using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Tests.Integration.Common.Commands;
using FunctionMonkey.Tests.Integration.Common.Commands.Model;

namespace FunctionMonkey.Tests.Integration.Common.Handlers
{
    class HttpPostCommandHandler : ICommandHandler<HttpPostCommand, SimpleResponse>
    {
        public Task<SimpleResponse> ExecuteAsync(HttpPostCommand command, SimpleResponse previousResult)
        {
            return Task.FromResult(new SimpleResponse
            {
                Message = command.Message,
                Value = command.Value
            });
        }
    }
}
