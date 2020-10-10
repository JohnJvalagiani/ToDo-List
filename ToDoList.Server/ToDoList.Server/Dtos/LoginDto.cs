using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoList.Server.Dtos
{
    public class LoginDto
    {
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
