using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Models
{
    public class MediaFiles: BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid FeedbackId { get; set; }
        public virtual Feedback Feedback { get; set; }
    }
}
