using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Server.Exeptions
{
    public class ToDoNotFoundException:Exception
    {
        public ToDoNotFoundException()
        {
                
        }

        public ToDoNotFoundException(string message )
            :base(message)
        {

        }


        public ToDoNotFoundException(string message,Exception inner)
           : base(message,inner)
        {

        }


    }
}
