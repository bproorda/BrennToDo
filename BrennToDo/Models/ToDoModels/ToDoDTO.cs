using System;

namespace BrennToDo.Models
{
    public class ToDoDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Assignee { get; set; }

        public int Difficulty { get; set; }

        public bool Completed { get; set; }

        public string CreatedBy { get; set; }
    }
}
