using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Service.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace IG.Core.Data
{
   public class ApplicationDbContext:DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context):base(context)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


           

        }

    }
}
