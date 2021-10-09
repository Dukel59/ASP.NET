using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.BLL.VMs.Ticket;
using TicketOffice.BLL.VMs.User;

namespace TicketOffice.BLL.Interfaces
{
    public interface ITicketService
    {
        Task<Guid> CreateTicketAsync(CreateTicket ticket, string userLogin);
        void Delete(InfoTicket ticket);
        List<InfoTicket> FindTicket(TicketSearch ticket);
    }
}
