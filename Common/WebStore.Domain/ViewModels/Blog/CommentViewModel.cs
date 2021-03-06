﻿using System;
using System.Collections.Generic;

namespace WebStore.Domain.ViewModels.Blog
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserViewModel Account { get; set; }
        public DateTime Time { get; set; }

        public List<CommentViewModel> ChildComments { get; set; } = new List<CommentViewModel>();
        public int? ParentCommentId { get; set; }
        public CommentViewModel ParentComment { get; set; }
    }
}
