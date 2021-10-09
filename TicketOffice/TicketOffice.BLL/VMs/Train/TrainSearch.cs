using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.BLL.VMs.Train
{
    public class TrainSearch
    {
        public Guid? Id { get; set; }
        public string TrainNumber { get; set; }
        public string Destination { get; set; }
        public DateTime? Departs { get; set; }
        public int? Track { get; set; }
    }
}
