using GoldstoneForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldstoneForum
{
    public partial class EditAnswer : System.Web.UI.Page
    {
        private int questionId;

        protected bool CanUserEditQuestion()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return false;
            }

            var context = new ApplicationDbContext();

            var user = context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var answerId = Convert.ToInt32(Request.Params["id"]);
            bool isAuthor =
                context.Answers.Find(answerId).User == user;

            if (this.User.IsInRole("Admin") || isAuthor)
            {
                return true;
            }

            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(this.Request.Params["id"], out this.questionId))
            {
                this.Response.Redirect("~/Default.aspx");
            }

            if (!CanUserEditQuestion())
            {
                this.Response.Redirect("~/Default.aspx");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new ApplicationDbContext();
            var answerId = Convert.ToInt32(Request.Params["id"]);
            var answer = context.Answers.Find(answerId);
            this.AnswerText.Text = answer.Text;

            this.DataBind();
        }

        protected void ButtonEditAnswer_Click(object sender, EventArgs e)
        {
            var answerId = Convert.ToInt32(Request.Params["id"]);
            var context = new ApplicationDbContext();
            var answer = context.Answers.Find(answerId);
            var text = this.AnswerText.Text;

            if (answer.Text != text)
            {
                answer.Text = text;
            }

            context.SaveChanges();
            Response.Redirect("~/QuestionForm.aspx?id=" + answer.Question.Id);
        }
    }
}