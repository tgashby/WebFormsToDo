using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using ToDo.Models;

namespace ToDo.Tasks
{
    public partial class ToDoDetail : System.Web.UI.Page
    {
        protected bool Edit { get; set; } = false;
        public string DetailTitle { get; set; } = "Add New ToDo";

        public string AddButtonText { get; set; } = "Add";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Edit = true;
                DetailTitle = "Edit ToDo";
                AddButtonText = "Update";
                ToDoForm.ChangeMode(FormViewMode.Edit);
            }

            (ToDoForm.FindControl("AddToDoButton") as Button).Text = AddButtonText + " ToDo";

            string toDoAction = Request.QueryString["Action"];
            if (toDoAction == "add")
            {
                (ToDoForm.FindControl("LabelAddStatus") as Label).Text = "ToDo Added";
            }

            if (toDoAction == "remnove")
            {
                (ToDoForm.FindControl("LabelAddStatus") as Label).Text = "ToDo Removed";
            }
        }

        protected void AddToDoButton_Click(object sender, EventArgs e)
        {
            using (ToDoContext _db = new ToDoContext())
            {
                ToDoItem toDo;
                if (Edit)
                {
                    int queryId = int.Parse(Request.QueryString["id"]);
                    toDo = _db.ToDos.First(t => t.Id == queryId);
                } 
                else
                {
                    toDo = new ToDoItem();
                }

                toDo.ToDoName = (ToDoForm.FindControl("ToDoName") as TextBox).Text;
                toDo.ToDoDescription = (ToDoForm.FindControl("ToDoDesc") as TextBox).Text;
                toDo.IsCompleted = (ToDoForm.FindControl("IsCompleted") as CheckBox).Checked;
                toDo.UserId = Context.User.Identity.GetUserId();
                toDo.ToDoTypeNameId = Convert.ToInt32((ToDoForm.FindControl("ToDoTypes") as DropDownList).SelectedValue);

                if (!Edit)
                {
                    _db.ToDos.Add(toDo);
                }

                _db.SaveChanges();

                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?Action=add");
            }
        }

        protected void RemoveToDoButton_Click(object sender, EventArgs e)
        {
            using (var _db = new ToDo.Models.ToDoContext())
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int toDoId = Convert.ToInt16(Request.QueryString["id"]);

                    var myItem = _db.ToDos.FirstOrDefault(t => t.Id == toDoId);
                    if (myItem != null)
                    {
                        _db.ToDos.Remove(myItem);
                        _db.SaveChanges();

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?Action=remove");
                    }
                }
            }
        }

        public IQueryable<ToDoItem> GetToDo([QueryString("id")] int? toDoId)
        {
            var _db = new ToDo.Models.ToDoContext();
            IQueryable<ToDoItem> query = _db.ToDos;

            if (toDoId.HasValue)
            {
                query = query.Where(t => t.Id == toDoId);
            } else
            {
                // Want to return an empty ToDo if no Id sent in
                query = null;
            }

            return query;
        }

        public IQueryable<ToDoTypeName> GetToDoTypeNames()
        {
            var _db = new ToDo.Models.ToDoContext();
            IQueryable<ToDoTypeName> query = _db.ToDoTypeName;

            return query;
        }
    }
}