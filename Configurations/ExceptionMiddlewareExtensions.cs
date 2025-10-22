using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace editorial_webapi.Configurations
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var result = new OperationResult<int>() { isValid = false, exceptions = new List<OperationException>() };
                        result.exceptions.Add(new OperationException("UNK", contextFeature.Error.Message));
                        if (contextFeature.Error.InnerException != null)
                        {
                            result.exceptions.Add(new OperationException("UNK", contextFeature.Error.InnerException.Message));
                        }
                        await context.Response.WriteAsync(JsonSerializer.Serialize<OperationResult>(result));
                    }
                });
            });
        }
    }
}
