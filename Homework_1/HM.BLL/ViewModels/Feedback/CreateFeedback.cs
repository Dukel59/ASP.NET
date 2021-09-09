using HM.BLL.ViewModels.MediaFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.BLL.ViewModels.Feedback
{
    public class CreateFeedback
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public List<CreateMediaFiles> MediaFiles { get; set; }
    }
}
