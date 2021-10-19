using Common.Models.Exception;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models.ApiModels;

namespace Task.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async System.Threading.Tasks.Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (FailedException ex)
            {
                var model = new ApiResponseModel<object>()
                {
                    ResponseCode = (int)ex.ErrorCode,
                    ResponseModel = null
                };
                await context.Response.WriteAsJsonAsync(model);
            }
            catch (Exception ex)
            {
                var model = new ApiResponseModel<object>()
                {
                    ResponseCode = (int)Common.Constants.ErrorCodes.GeneralException,
                    ResponseModel = null
                };
                await context.Response.WriteAsJsonAsync(model);
            }
        }
    }
}
