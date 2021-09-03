using HM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DAL.Patterns
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<TEntity> UpdeatAsync(TEntity item);
        Task DeleteAsync(Guid id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(Guid id);
        Task Save();
    }
}
