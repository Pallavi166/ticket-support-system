using Microsoft.AspNetCore.Mvc;
using TicketSupport.API.Data;
using TicketSupport.API.DTOs;
using TicketSupport.API.Models;



namespace TicketSupport.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;

        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");

            }

            return Ok(user);
        }
      

    }
}
