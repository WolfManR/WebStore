using System;
using System.Collections.Generic;

using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Subject { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string MainImageUrl { get; set; }
        public string ShortDesc { get; set; }

        public IEnumerable<string> Text { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
