using FilmsApi.Core.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace WebApplication1.Middlewares
{
    public class ErrorMiddleWare
    {
       private readonly RequestDelegate _next;

        public ErrorMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (ValidationException ex)
            {
                await WriteAsync(ctx, (int)HttpStatusCode.BadRequest, "Validation failed", ex.Errors);
            }
            catch(NotFoundException ex)
            {
                await WriteAsync(ctx, (int)HttpStatusCode.NotFound, ex.Message);
            }
            catch(Exception ex)
            {
                await WriteAsync(ctx,(int) HttpStatusCode.InternalServerError,"Something went wrong");
            }
           
        }

        private static Task WriteAsync(HttpContext ctx, int status, string msg, object? errors = null)
        {
            ctx.Response.StatusCode = status;
            ctx.Response.ContentType = "application/json";
            var body = JsonSerializer.Serialize(new {message = msg, errors = errors});
            return ctx.Response.WriteAsync(body);
        }
    }
}
