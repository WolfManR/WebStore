using Microsoft.AspNetCore.Mvc;

using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Blog;
using WebStore.Interfaces.Services;
using WebStore.Services.Services.InMemory;

namespace WebStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepo<User> repoAccount;
        private readonly IRepo<BlogPost> repoBlogPost;
        public BlogController(IRepo<BlogPost> repoBlogPost)
        {
            this.repoAccount = new InMemoryAccountDataService();
            this.repoBlogPost = repoBlogPost;
        }
        public IActionResult BlogList()
        {
            var blogs = repoBlogPost.GetAll();
            var shortViews = (
                from item in blogs
                let author = repoAccount.GetById(item.AuthorAccountId)
                select new BlogPostShortInfoViewModel
                {
                    Id = item.Id,
                    Author = new UserViewModel {Id = author.Id, AvatarUrl = author.AvatarUrl, Firstname = author.Firstname, Surname = author.Surname},
                    MainImageUrl = item.MainImageUrl,
                    Subject = item.Subject,
                    RegistrationTime = item.RegistrationTime,
                    ShortDesc = item.ShortDesc,
                    Tags = item.Tags.ToList()
                }).ToList();

            return View(shortViews);
        }

        public IActionResult BlogSingle(int id)
        {
            if (id < 0) return BadRequest();

            var post = repoBlogPost.GetById(id);
            if (post is null) return NotFound();

            var comments = post.Comments;
            var commentsViews = (
                from item in comments
                let account = repoAccount.GetById(item.AccountId)
                select new CommentViewModel
                {
                    Id = item.Id,
                    Account = new UserViewModel {Id = account.Id, AvatarUrl = account.AvatarUrl, Firstname = account.Firstname, Surname = account.Surname},
                    Text = item.Text,
                    Time = item.Time,
                    ParentCommentId = item.ParentCommentId
                }).ToList();

            foreach (var view in commentsViews)
            {
                if (view.ParentCommentId is null) continue;

                var childs = commentsViews.Where(c => c.ParentCommentId == view.Id);
                foreach (var item in childs)
                {
                    item.ParentComment = view;
                    view.ChildComments.Add(item);
                }
            }

            var parentComments = commentsViews.Where(x => x.ParentCommentId is null);
            var author = repoAccount.GetById(post.AuthorAccountId);
            return View(new BlogPostViewModel
            {
                Id = post.Id,
                Author = new UserViewModel { Id = author.Id, AvatarUrl = author.AvatarUrl, Firstname = author.Firstname, Surname = author.Surname },
                MainImageUrl = post.MainImageUrl,
                RegistrationTime = post.RegistrationTime,
                Subject = post.Subject,
                Tags = post.Tags.ToList(),
                Text = post.Text.ToList(),
                Comments = parentComments.ToList()
            });
        }
    }
}
