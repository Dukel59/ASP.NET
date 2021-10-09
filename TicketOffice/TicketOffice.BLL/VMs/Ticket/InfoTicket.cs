using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.BLL.VMs.Ticket
{
    public class InfoTicket
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string TrainNumber { get; set; }
        public string Destination { get; set; }
        public int TrainCarNumber { get; set; }
        public int PlaceNumber { get; set; }
        public DateTime Departs { get; set; }
        public int Track { get; set; }
    }
}
