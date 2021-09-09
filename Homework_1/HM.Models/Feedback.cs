using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Models
{
    public class Feedback: BaseEntity 
    {
        public string AuthorName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<MediaFiles> MediaFiles { get; set; }
    }
}
