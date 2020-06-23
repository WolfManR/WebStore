using System;
using System.Collections.Generic;

namespace WebStore.Domain.ViewModels.Blog
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public UserViewModel Author { get; set; }
        public string Subject { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string MainImageUrl { get; set; }

        public List<string> Text { get; set; }
        public List<string> Tags { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}
