using Microsoft.AspNetCore.Mvc;
using ProductService.Domain.Exceptions;

using System.Net;
using System.Net.WebSockets;
using System.Text.Json;

namespace ProductService.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex )
            {

                _logger.LogError(ex, "Error no manejado.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            var errorResult = new ErrorResponse();

            switch (ex)
            {
                case NotFoundException nf:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResult.Message = nf.Message;
                    break;
                case ValidationException ve:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResult.Message = "Error de validacion";
                    errorResult.Errors = ve.Errors;
                    break;
                case DomainException de:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    errorResult.Message = de.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResult.Message = "Ocurrio un error inesperado";
                    break;
            }

            var json = JsonSerializer.Serialize(errorResult);

            await context.Response.WriteAsync(json);


        }

    }

    public class ErrorResponse
    {
      public string Message { get; set; }
      public object ? Errors { get; set; }
    }

}
