using HM.BLL.ViewModels.Comment;
using HM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL.Interfaces
{
   public  interface ICommentService
    {
        Task<Guid> CreateCommentAsync(CreateComment comment);
        List<InfoComment> FindCommentsByFunc(Func<Comment, bool> func);
    }
}
