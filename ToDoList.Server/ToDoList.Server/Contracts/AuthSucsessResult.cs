using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Server.Contracts
{
    public class AuthSucsessResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }


    }
}
