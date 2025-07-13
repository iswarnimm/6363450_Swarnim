using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace EmployeeFilterDemo.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = context.Exception.Message;

            File.AppendAllText("errors.txt", $"[{DateTime.Now}] {error}\n");

            context.Result = new ObjectResult("An error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
