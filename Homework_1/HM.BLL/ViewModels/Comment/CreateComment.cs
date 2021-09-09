using System;
using System.Collections.Generic;
using System.Text;

namespace HM.BLL.ViewModels.Comment
{
    public class CreateComment
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public Guid FeedbackId { get; set; }
    }
}
