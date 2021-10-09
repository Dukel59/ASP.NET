using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.Models
{
    public class Ticket : BaseEntity
    {
        public DateTime CreationTime { get; set; }
        public int PlaceNumber { get; set; }
        public int TrainCarNumber { get; set; }

        public Guid TrainId { get; set; }
        public virtual Train Train { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
