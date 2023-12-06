using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using ToDo.Models;

namespace ToDo.Tasks
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<ToDoItem> GetToDos()
        {
            var _db = new ToDo.Models.ToDoContext();
            string userId = Context.User.Identity.GetUserId();
            IQueryable<ToDoItem> query = _db.ToDos.Where(t => t.UserId == userId);

            return query;
        }

        protected void IsCompleted_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox isCompleted = (CheckBox)sender;

            ListViewDataItem dataItem = isCompleted.Parent as ListViewDataItem;
            int toDoId = int.Parse((dataItem.FindControl("ToDoId") as Label).Text);

            var _db = new ToDo.Models.ToDoContext();
            ToDoItem toDo = _db.ToDos.First(t => t.Id ==  toDoId);
            toDo.IsCompleted = isCompleted.Checked;

            _db.SaveChanges();
        }
    }
}