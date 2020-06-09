﻿using BrennToDo.Models;
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
    }
}