using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Server.CustomExceptionMiddleware;

namespace ToDoList.Server.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {



        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
            {

            app.UseMiddleware<ExceptionMiddleware>();

            }

    }
}
