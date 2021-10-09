using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Models;

namespace TicketOffice.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext db;
        public UnitOfWork(DbContextOptions<AppDbContext> options)
        {
            db = new AppDbContext(options);
        }

        private IRepository<User> _users;
        private IRepository<Train> _trains;
        private IRepository<Ticket> _tickets;

        public IRepository<User> Users => _users ?? (_users = new Repository<User>(db));
        public IRepository<Train> Trains => _trains ?? (_trains = new Repository<Train>(db));
        public IRepository<Ticket> Tickets => _tickets ?? (_tickets = new Repository<Ticket>(db));

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing)
            {
                db.Dispose();
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
