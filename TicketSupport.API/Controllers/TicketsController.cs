using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSupport.API.Data;
using TicketSupport.API.Models;

namespace TicketSupport.API.Controllers
{
   

        [ApiController]
        [Route("api/[controller]")]
        public class TicketsController : ControllerBase
        {

            private readonly AppDbContext _context;

       
            public TicketsController(AppDbContext context)
            {
                _context = context;

            }


            [HttpPost("create")]
            public IActionResult CreateTicket(Ticket ticket)
            {
                ticket.Status = "Open";

                ticket.CreatedDate = DateTime.Now;
                ticket.TicketNumber = "TKT" + DateTime.Now.Ticks;
                _context.Tickets.Add(ticket);
                _context.SaveChanges();

                //
                var history = new TicketStatusHistory
                {
                    TicketId = ticket.TicketId,
                    Status = "Open",
                    UpdatedBy = ticket.CreatedBy,
                    UpdatedDate = DateTime.Now,

                };
                _context.TicketStatusHistories.Add(history);
                _context.SaveChanges();


                return Ok(ticket);
            }


            [HttpGet("list/{userId}/{role}")]
            public IActionResult GetTickets(int userId, string role)
            {
                if (role == "Admin")
                {
                    var tickets = _context.Tickets.ToList();
                    return Ok(tickets);
                }

                var userTickets = _context.Tickets
                    .Where(x => x.CreatedBy == userId)
                    .ToList();

                return Ok(userTickets);
            }

            // 3️⃣ GET TICKET DETAILS
            [HttpGet("details/{ticketId}")]
            public IActionResult GetTicketDetails(int ticketId)
            {
                var ticket = _context.Tickets
                    .FirstOrDefault(x => x.TicketId == ticketId);

                if (ticket == null)
                    return NotFound("Ticket not found");

                return Ok(ticket);
            }

            // 4️⃣ ASSIGN TICKET (ADMIN)
            [HttpPost("assign")]
            public IActionResult AssignTicket(int ticketId, int adminId)
            {
                var ticket = _context.Tickets.Find(ticketId);

                if (ticket == null)
                    return NotFound("Ticket not found");

                ticket.AssignedTo = adminId;

                _context.SaveChanges();

                return Ok("Ticket assigned successfully");
            }

            // 5️⃣ UPDATE STATUS
            [HttpPost("status")]
            public IActionResult UpdateStatus(int ticketId, string status, int userId)
            {
                var ticket = _context.Tickets.Find(ticketId);

                if (ticket == null)
                    return NotFound("Ticket not found");

                if (ticket.Status == "Closed")
                    return BadRequest("Closed ticket cannot be modified");

                ticket.Status = status;

                _context.SaveChanges();

                // Save history
                var history = new TicketStatusHistory
                {
                    TicketId = ticketId,
                    Status = status,
                    UpdatedBy = userId,
                    UpdatedDate = DateTime.Now
                };

                _context.TicketStatusHistories.Add(history);
                _context.SaveChanges();

                return Ok("Status updated successfully");
            }

            // 6️⃣ ADD COMMENT
            [HttpPost("comment")]
            public IActionResult AddComment([FromBody] TicketComment comment)
            {
                comment.CreatedDate = DateTime.Now;

                _context.TicketComments.Add(comment);

                _context.SaveChanges();

                return Ok("Comment added");
            }

            // 7️⃣ GET TICKET HISTORY
            [HttpGet("history/{ticketId}")]
            public IActionResult GetHistory(int ticketId)
            {
                var history = _context.TicketStatusHistories
                    .Where(x => x.TicketId == ticketId)
                    .OrderBy(x => x.UpdatedDate)
                    .ToList();

                return Ok(history);
            }
        }
    }



