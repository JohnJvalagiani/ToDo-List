using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Server.Domain
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Sacsess { get; set; }
        public string Errors { get; set; }


    }
}
