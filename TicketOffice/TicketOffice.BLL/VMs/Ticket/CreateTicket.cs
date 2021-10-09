using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.BLL.VMs.Ticket
{
    public class CreateTicket
    {
        public Guid UserId { get; set; }
        public Guid TrainId { get; set; }
        public int PlaceNumber { get; set; }
        public int TrainCarNumber { get; set; }
    }
}
