using System;
using System.Collections.Generic;

namespace WebStore.ViewModels
{
    public class BlogPostShortInfoViewModel
    {
        public int Id { get; set; }
        public UserViewModel Author { get; set; }
        public string Subject { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string MainImageUrl { get; set; }
        public string ShortDesc { get; set; }

        public List<string> Tags { get; set; }
    }
}
