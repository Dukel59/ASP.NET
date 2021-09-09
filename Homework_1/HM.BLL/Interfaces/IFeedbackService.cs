using HM.BLL.ViewModels.Feedback;
using HM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL.Interfaces
{
    public interface IFeedbackService
    {
        Task<Guid> CreateFeedbackAsync(CreateFeedback feedback);
        List<InfoFeedback> FindFeedbacksByFunc(Func<Feedback, bool> func);
    }
}
