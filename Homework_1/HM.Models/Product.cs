using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
