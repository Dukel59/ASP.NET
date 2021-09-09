using HM.BLL.ViewModels.Comment;
using HM.BLL.ViewModels.MediaFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.BLL.ViewModels.Feedback
{
    public class InfoFeedback
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public string ProductName { get; set; }
        public DateTime CreationDate { get; set; }
        public List<InfoComment> Comments { get; set; } = new List<InfoComment>();
        public List<CreateMediaFiles> MediaFiles { get; set; } = new List<CreateMediaFiles>();
    }
}
