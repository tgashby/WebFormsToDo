using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class ToDoInitializer : DropCreateDatabaseIfModelChanges<ToDoContext>
    {
        protected override void Seed(ToDoContext context)
        {
            GetToDoTypeNames().ForEach(n => context.ToDoTypeName.Add(n));
        }

        private static List<ToDoTypeName> GetToDoTypeNames()
        {
            var toDoTypeNames = new List<ToDoTypeName>
            {
                new ToDoTypeName
                {
                    Id = 1,
                    Name = "Basic"
                },
                new ToDoTypeName{ 
                    Id = 2,
                    Name = "Recurring"
                }, new ToDoTypeName
                {
                    Id= 3,
                    Name = "Deadline"
                }
            };

            return toDoTypeNames;
        }
    }
}