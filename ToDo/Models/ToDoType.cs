using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class ToDoType
    {
        [ScaffoldColumn(false)] 
        public int Id { get; set; }

        [Required]
        public bool IsRecurring { get; set; } = false;

        [Required]
        public DateTime? ToDoDeadline { get; set; } = null;

        public int? ToDoTypeNameId { get; set; }

        public virtual ToDoTypeName ToDoTypeName { get; set; }
    }
}