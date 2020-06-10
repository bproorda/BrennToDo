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
                    Id  = 1,
                    Title = "Walk The Dog",
                    Assignee = "Brenn",
                    Difficulty = 3,
                    DueDate = new DateTime(2020, 7, 10, 5, 0, 000, DateTimeKind.Utc)
                }
                );
        }


        public DbSet<BrennToDo.Models.ToDo> ToDo { get; set; }
    }
}
