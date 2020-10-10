using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ToDoList.Core.Data;
using ToDoList.Core.Identity;

namespace Service.Core.Data
{
   public  class ToDo:BaseEntity
    {
        public string Titel { get; set; }
        public string Content { get; set; }
        public bool Done { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User user { get; set; }
    }
}
