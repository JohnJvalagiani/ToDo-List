using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Server.Dtos
{
    public class CreateToDo
    {
        public string Titel { get; set; }
        public string Content { get; set; }

    }
}
