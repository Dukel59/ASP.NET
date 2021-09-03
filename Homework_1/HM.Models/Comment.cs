using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Models
{
    public class Comment: BaseEntity
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public Product ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
