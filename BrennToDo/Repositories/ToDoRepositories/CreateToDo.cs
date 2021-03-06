﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrennToDo.Repositories.ToDoRepositories
{
    public class CreateToDo
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Assignee { get; set; }

        public int Difficulty { get; set; }
    }
}
