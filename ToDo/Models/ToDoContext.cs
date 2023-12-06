using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("DefaultConnection")
        {
        }
        public DbSet<ToDoItem> ToDos { get; set; }
        public DbSet<ToDoType> ToDoTypes { get; set; }
        public DbSet<ToDoTypeName> ToDoTypeName { get; set; }
    }
}