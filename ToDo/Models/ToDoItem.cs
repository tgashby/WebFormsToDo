using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoItem
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name = "ToDo Name")]
        public string ToDoName { get; set; }

        [Required, StringLength(1000), Display(Name = "ToDo Description"), DataType(DataType.MultilineText)]
        public string ToDoDescription { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false;

        [Required]
        public string UserId { get; set; }

        public int? ToDoTypeNameId { get; set; }

        public virtual ToDoTypeName ToDoTypeName { get; set; }
    }
}