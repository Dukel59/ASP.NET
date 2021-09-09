using System;
using System.Collections.Generic;
using System.Text;

namespace HM.BLL.ViewModels.MediaFiles
{
    public class CreateMediaFiles
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public Guid? FeedbackId { get; set; }
    }
}
