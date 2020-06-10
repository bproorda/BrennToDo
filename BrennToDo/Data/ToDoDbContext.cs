using BrennToDo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrennToDo.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                .HasData(
                new ToDo
                {
                    Id = 1,
                    Title = "Walk The Dog",
                    Assignee = "Brenn",
                    Difficulty = 3,
                    DueDate = new DateTime(2020, 7, 10, 5, 0, 000, DateTimeKind.Utc)
                },
                new ToDo {
                Id = 2,
                    Title = "Clean up after Dog",
                    Assignee = "Graeme",
                    Difficulty = 5,
                    DueDate = new DateTime(2020, 7, 10, 5, 0, 000, DateTimeKind.Utc),
                    CreatedByUserId = "7304a689-e2ff-4b12-a49c-103675becb39"
                }
                );
        }

        
        public DbSet<BrennToDo.Models.ToDo> ToDo { get; set; }
    }
}
