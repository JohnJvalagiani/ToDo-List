using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Server.Extensions
{
    public static class GeneralExtentions
    {


        public static string GetUserId(this HttpContext httpContext )
         {

            if (httpContext.User == null)
                return string.Empty;

            return httpContext.User.Claims.Single(u => u.Type == "id").Value;


        }

    }
}
