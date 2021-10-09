using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.Models
{
    public class Train : BaseEntity
    {
        public string TrainNumber { get; set; }
        public string Destination { get; set; }
        public DateTime Departs { get; set; }
        public int Track { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
