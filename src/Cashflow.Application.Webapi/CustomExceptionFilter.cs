using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Cashflow.Application.Webapi
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
        }
    }
}
