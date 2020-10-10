using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Server.Domain;

namespace ToDoList.Core.Identity
{
    public class IdentityDb:IdentityDbContext<User>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public IdentityDb(DbContextOptions<IdentityDb> contextOptions):base(contextOptions)
        {

        }


    }
}
