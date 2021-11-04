using KlinikAPI.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KlinikAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ApiError response;
                HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
                string message;
                var exceptionType = ex.GetType();

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    StatusCode = HttpStatusCode.Forbidden;
                    message = "You Are Not Authorized";
                }
                else {
                    StatusCode = HttpStatusCode.InternalServerError;
                    message = "Some Unknown Error Occured";
                }

                if (env.IsDevelopment())
                {
                    response = new ApiError((int)StatusCode, ex.StackTrace.ToString(), ex.InnerException.Message, ex.InnerException.StackTrace);
                }
                else 
                {
                    response = new ApiError((int)StatusCode, message);
                }
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }

    
}
