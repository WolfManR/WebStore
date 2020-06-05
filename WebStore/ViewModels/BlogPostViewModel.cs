using System;
using System.Collections.Generic;

namespace WebStore.ViewModels
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public AccountViewModel Author { get; set; }
        public string Subject { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string MainImageUrl { get; set; }

        public List<string> Text { get; set; }
        public List<string> Tags { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}
