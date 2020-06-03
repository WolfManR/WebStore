using System;

using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int AccountId { get; set; }
        public DateTime Time { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
