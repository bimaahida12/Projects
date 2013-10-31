using GoldstoneForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldstoneForum
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            var context = new ApplicationDbContext();
            var category = context.Categories.Find(id);
            this.CategoryTitle.Text = category.Name;
            this.CategoryTitle.DataBind();
            //var questions = context.Questions.Where(quest => quest.Category.Id == id).ToList();
            //this.ListViewCategories.DataSource = questions;
            //this.ListViewCategories.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<GoldstoneForum.Models.Question> ListViewCategories_GetData()
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            var context = new ApplicationDbContext();
            var questions = context.Questions.Where(quest => quest.Category.Id == id);
            return questions;
        }

        protected void VotePositive_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            var context = new ApplicationDbContext();
        }

        protected void Vote_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();
            var question = context.Questions.Find(id);
            var username = this.User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.UserName == username);

            if (e.CommandName == "Vote")
            {
                question.Votes.Add(new QuestionVotes() { User = user });
            }

            if (e.CommandName == "Unvote")
            {
                var vote = question.Votes.FirstOrDefault(v => v.User == user);
                question.Votes.Remove(vote);
            }

            context.SaveChanges();

            this.Page.DataBind();
        }


        protected bool CanUserVoteOnAnswer(int id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var context = new ApplicationDbContext();

            var question = context.Questions.Find(id);
            var username = this.User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.UserName == username);

            if (question.Votes.Any(v => v.User == user))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool CanUserUnVoteOnAnswer(int id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return false;
            }
            else
            {
                return !CanUserVoteOnAnswer(id);
            }
        }
    }
}