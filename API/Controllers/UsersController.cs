using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Data;
using API.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        // endpoint to get all the users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        // endpoint to get an specific user
        // api/users/3
        [HttpGet("{id}")]
        public async Task< ActionResult<AppUser> > GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}