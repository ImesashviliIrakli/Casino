using BuildingBlocks.Domain.Errors;
using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace BuildingBlocks.Applictaion.Middleware;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = Result.Failure(GlobalErrors.SystemFailure(ex.Message));

            string json = JsonSerializer.Serialize(result);

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}

