using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Models;

namespace TicketOffice.DAL.Patterns
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity item)
        {
            try
            {
                var newEntity = await _db.Set<TEntity>().AddAsync(item);
                await Save();
                return newEntity.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = GetByIdAsync(id).GetAwaiter().GetResult();

            _db.Set<TEntity>().Remove(entity);
            await Save();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Save()
        {
            _db.SaveChangesAsync().GetAwaiter().GetResult();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity item)
        {
            _db.Set<TEntity>().Update(item);
            await Save();
            return item;
        }
    }
}
