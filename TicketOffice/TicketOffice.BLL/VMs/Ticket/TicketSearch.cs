using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.BLL.VMs.Ticket
{
    public class TicketSearch
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string TrainNumber { get; set; }
        public string UserLogin { get; set; }
    }
}
