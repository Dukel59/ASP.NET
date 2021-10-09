using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketOffice.BLL.Interfaces;
using TicketOffice.BLL.VMs.Ticket;

namespace TicketOffice.Controllers
{
    [Route("ticket")]
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService service)
        {
            ticketService = service;
        }

        [HttpGet]
        [Authorize]
        [Route("tickets")]
        public IActionResult Tickets(TicketSearch search)
        {
            search.UserLogin = User.Identity.Name;
            var tickets = ticketService.FindTicket(search);
            return View(tickets);
        }

        [HttpGet]
        [Authorize]
        [Route("create/{id}")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [Route("create/{id}")]
        public IActionResult Create(CreateTicket ticket, Guid id)
        {
            var user = User.Identity.Name;
            ticket.TrainId = id;
            ticketService.CreateTicketAsync(ticket, user);
            return RedirectToAction("Tickets", "Ticket");
        }

        [HttpGet]
        [Authorize]
        [Route("Delete")]
        public IActionResult Delete(TicketSearch search)
        {
            search.UserLogin = User.Identity.Name;
            var ticket = ticketService.FindTicket(search).FirstOrDefault();
            return View(ticket);
        }

        [HttpPost]
        [Authorize]
        [Route("Delete")]
        public IActionResult Delete(InfoTicket t)
        {
            ticketService.Delete(t);
            return RedirectToAction("Tickets", "Ticket");
        }
    }
}
