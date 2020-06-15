using BrennToDo.Models;
using Microsoft.AspNetCore.Identity;
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

            var admin = new IdentityRole
            {
                Id = "admin",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "17722115-21fd-4451-8db4-e99f5c602421",
            };
            var editor = new IdentityRole
            {
                Id = "editor",
                Name = "Editor",
                NormalizedName = "EDITOR",
                ConcurrencyStamp = "79b16ad0-71fc-4d45-851a-c8c0544adf1d",
            };
            var user = new IdentityRole
            {
                Id = "user",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "79b76ad0-79fc-4d46-852a-c8c05a4adf1d",
            };
            builder.Entity<IdentityRole>()
               .HasData(admin, editor, user);

            builder.Entity<IdentityRoleClaim<string>>()
               .HasData(
                   new IdentityRoleClaim<string> { Id = 1, RoleId = "admin", ClaimType = "Permissions", ClaimValue = "delete" },
                   new IdentityRoleClaim<string> { Id = 2, RoleId = "admin", ClaimType = "Permissions", ClaimValue = "create" },
                   new IdentityRoleClaim<string> { Id = 3, RoleId = "admin", ClaimType = "Permissions", ClaimValue = "update" },
                   new IdentityRoleClaim<string> { Id = 4, RoleId = "editor", ClaimType = "Permissions", ClaimValue = "update" },
                   new IdentityRoleClaim<string> { Id = 5, RoleId = "user", ClaimType = "Permissions", ClaimValue = "create" },
                   new IdentityRoleClaim<string> { Id = 6, RoleId = "user", ClaimType = "Permissions", ClaimValue = "update" }
               );
            builder.Entity<ToDoUser>()
                .HasData( new ToDoUser
                {
                    FirstName = "Brenn", LastName = "Roorda", 
                    Email = "bproorda@gmail.com", EmailConfirmed = true, 
                    Id = "bproorda", UserName = "bproorda",
                    ConcurrencyStamp = "79b76ad0-79fc-4d46-952a-c8c15a4adf1d",
                });
        }

    }
}
