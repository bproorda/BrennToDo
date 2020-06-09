using BrennToDo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrennToDo.Data
{
    public class UserDbContext : IdentityDbContext<ToDoUser>
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ToDoUser>()
                .HasData( new ToDoUser
                {
                    FirstName = "Brenn", LastName = "Roorda", Email = "bproorda@gmail.com", EmailConfirmed = true, Id = "bproorda", UserName = "bproorda"
                });
        }
    }
}
