using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace Web;

public static class GlobalExceptionHandlers
{
    public static void UseExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                IExceptionHandlerFeature? exception = context.Features.Get<IExceptionHandlerFeature>();

                if (exception != null)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        status = context.Response.StatusCode,
                        message = exception.Error.Message,
                        detailed = exception.Error
                    }));
                }
            });
        });
    }
}

