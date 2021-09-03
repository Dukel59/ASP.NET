using System;
using System.Collections.Generic;
using System.Text;

namespace HM.BLL.Interfaces
{
    public interface ICreateComment
    {
        bool LeaveFeedback(string productName, string category, int rate, string text);
        bool LeaveComment(string text, Guid commentId);
    }
}
