using HM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HM.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContextOptions<AppDbContext> options)
        {
            _db = new AppDbContext(options);
        }

        private readonly AppDbContext _db;
        private IRepository<Product> _products;
        private IRepository<Comment> _comments;
        private IRepository<Feedback> _feedbacks;
        private IRepository<MediaFiles> _mediafiles;

        public IRepository<Product> Products => _products ?? (_products = new Repository<Product>(_db));
        public IRepository<Comment> Comments => _comments ?? (_comments = new Repository<Comment>(_db));
        public IRepository<Feedback> Feedbacks => _feedbacks ?? (_feedbacks = new Repository<Feedback>(_db));
        public IRepository<MediaFiles> MediaFiles => _mediafiles ?? (_mediafiles = new Repository<MediaFiles>(_db));

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if(disposing)
            {
                _db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
