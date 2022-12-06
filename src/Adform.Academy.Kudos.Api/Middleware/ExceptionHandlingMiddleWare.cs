using Adform.Academy.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace Adform.Academy.Kudos.Api.Middleware
{
    public class ExceptionHandlingMiddleWare
    {
        public class ExceptionHandlingMiddleware
        {
            private readonly RequestDelegate _next;

            public ExceptionHandlingMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception error)
                {
                    var response = context.Response;
                    response.ContentType = "application/json";

                    response.StatusCode = error switch
                    {
                        NoKudosOnThisDateException => (int)HttpStatusCode.NotFound,
                        KudosNotFoundException => (int)HttpStatusCode.NotFound,
                        EmployeeNotFoundException => (int)HttpStatusCode.NotFound,
                        SenderAndReceiverCantBeEqualException => (int)HttpStatusCode.BadRequest,
                        _ => (int)HttpStatusCode.InternalServerError,
                    };

                    var result = JsonSerializer.Serialize(new { message = error?.Message });
                    await response.WriteAsync(result);
                }
            }
        }
    }
}
