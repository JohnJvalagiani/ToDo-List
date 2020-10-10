using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoList.Core.Data
{
    public class BaseEntity
    {
        [Key]
        virtual public int Id { get; set; }

    }
}
