using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.BLL.Interfaces;
using TicketOffice.BLL.VMs.Ticket;
using TicketOffice.DAL.Patterns;
using TicketOffice.Models;

namespace TicketOffice.BLL.Services
{
    public class TicketService : ITicketService
    {
        public TicketService(IUnitOfWork _db)
        {
            db = _db;
        }
        private readonly IUnitOfWork db;

        public async Task<Guid> CreateTicketAsync(CreateTicket ticket, string userLogin)
        {
            try
            {
                var user = db.Users.GetAll().Where(u => u.Login == userLogin).FirstOrDefault();
                var dbTicket = new Ticket()
                {
                    UserId = user.Id,
                    CreationTime = DateTime.Now,
                    TrainId = ticket.TrainId,
                    TrainCarNumber = ticket.TrainCarNumber,
                    PlaceNumber = ticket.PlaceNumber
                };
                dbTicket = await db.Tickets.CreateAsync(dbTicket);
                return dbTicket.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoTicket> FindTicket(TicketSearch ticket)
        {
            try
            {
                var user = db.Users.GetAll().Where(u => u.Login == ticket.UserLogin).FirstOrDefault();

                var findTicket = db.Tickets.GetAll().Where(t => t.UserId == user.Id);

                if (ticket.TrainNumber != null)
                {
                    findTicket = findTicket.Where(t => t.Train.TrainNumber == ticket.TrainNumber);
                }
                if (ticket.CreationDate != null)
                {
                    findTicket = findTicket.Where(t => t.CreationTime == ticket.CreationDate);
                }
                if(ticket.Id != null)
                {
                    findTicket = findTicket.Where(t => t.Id == ticket.Id);
                }

                return findTicket.Select(t => new InfoTicket()
                {
                    Id = t.Id,
                    CreationDate = t.CreationTime,
                    TrainNumber = t.Train.TrainNumber,
                    TrainCarNumber = t.TrainCarNumber,
                    PlaceNumber = t.PlaceNumber,
                    Destination = t.Train.Destination,
                    Departs = t.Train.Departs,
                    Track = t.Train.Track
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(InfoTicket t)
        {
            try
            {
                db.Tickets.DeleteAsync(t.Id);
                db.SaveAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
