using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Server.Dtos
{
    public class ReadToDo
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }

    }
}
