using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Models
{
    public class Comment : BaseEntity
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid FeedbackId { get; set; }
        public virtual Feedback Feedback { get; set; }
    }
}
