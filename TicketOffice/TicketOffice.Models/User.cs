using System;
using System.Collections.Generic;
using System.Text;

namespace TicketOffice.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Guid? RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
