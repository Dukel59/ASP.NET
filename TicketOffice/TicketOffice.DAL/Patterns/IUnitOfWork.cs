using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Models;

namespace TicketOffice.DAL.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Train> Trains { get; }
        IRepository<Ticket> Tickets { get; }

        Task SaveAsync();
    }
}
