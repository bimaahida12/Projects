using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.ViewModels;

    using PagedList;

    public class CategoriesController : Controller
    {
        IUowData db = new UowData();

        
        [ValidateInput(false)]
        public ActionResult CategoryPosts(string currentFilter, string searchString, int? page, int id)
        {

            //string[] roles = Roles.GetRolesForUser("asdasd");
            if (searchString != null)
            {
                if (searchString.Contains('<'))
                {
                    searchString = searchString.Replace("<", "&lt;");
                }
                if (searchString.Contains('>'))
                {
                    searchString = searchString.Replace(">", "&gt;");
                }
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var singleComment = db.Comments.All().Select(CommentViewModel.FromComment).Where(c => c.Post.Id == postId);

            //var postUser = singleComment.FirstOrDefault().User.UserName;


            var posts = db.Posts.All().Select(PostCategoryUserViewModel.FromPost).Where(po => po.CategoryId == id);

            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())
                                       || s.PostContent.ToUpper().Contains(searchString.ToUpper()));
            }

            var orderedPosts = posts.OrderByDescending(post => post.Id);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(orderedPosts.ToPagedList(pageNumber, pageSize));
        }
	}
}