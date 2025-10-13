using Services.Contracts;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Entities.ErrorModel;
using Entities.Exceptions;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        // Yeni hata eklenmek istendiğinde  switch bölümüne bu hata eklenir! 
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound ,
                              _ => StatusCodes.Status500InternalServerError
                        };

                        //  Logger'ı her istek için request scope'dan al
                        var logger = context.RequestServices.GetRequiredService<ILoggerService>();
                        logger.LogError($"Bir hata oluştu: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}