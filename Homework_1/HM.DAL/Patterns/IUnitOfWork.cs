using HM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HM.DAL.Patterns
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Comment> Comments { get; }

        Task SaveAsync();
    }
}
