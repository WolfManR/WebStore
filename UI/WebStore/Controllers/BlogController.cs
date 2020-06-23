using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Blog;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services.InMemory;

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
            var Blogs = repoBlogPost.GetAll();
            List<BlogPostShortInfoViewModel> shortViews = new List<BlogPostShortInfoViewModel>();
            foreach (var item in Blogs)
            {
                var author = repoAccount.GetById(item.AuthorAccountId);
                shortViews.Add(new BlogPostShortInfoViewModel
                {
                    Id = item.Id,
                    Author=new UserViewModel {Id=author.Id,AvatarUrl=author.AvatarUrl,Firstname=author.Firstname,Surname=author.Surname },
                    MainImageUrl = item.MainImageUrl,
                    Subject = item.Subject,
                    RegistrationTime = item.RegistrationTime,
                    ShortDesc = item.ShortDesc,
                    Tags = item.Tags.ToList()
                });
            }
            return View(shortViews);
        }

        public IActionResult BlogSingle(int id)
        {
            if (id < 0) return BadRequest();

            var post = repoBlogPost.GetById(id);
            if (post is null) return NotFound();

            var comments = post.Comments;
            List<CommentViewModel> comments_views = new List<CommentViewModel>();
            foreach (var item in comments)
            {
                var account = repoAccount.GetById(item.AccountId);

                comments_views.Add(new CommentViewModel
                {
                    Id = item.Id,
                    Account = new UserViewModel { Id = account.Id, AvatarUrl = account.AvatarUrl, Firstname = account.Firstname, Surname = account.Surname },
                    Text = item.Text,
                    Time = item.Time,
                    ParentCommentId=item.ParentCommentId
                });
            }

            foreach (var view in comments_views)
            {
                if (view.ParentCommentId is null) continue;

                var childs = comments_views.Where(c => c.ParentCommentId == view.Id);
                foreach (var item in childs)
                {
                    item.ParentComment = view;
                    view.ChildComments.Add(item);
                }
            }

            var parent_comments = comments_views.Where(x => x.ParentCommentId is null);
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
                Comments = parent_comments.ToList()
            });
        }
    }
}
