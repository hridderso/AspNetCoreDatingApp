using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Data;
using API.Entities;
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

        // api/users
        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers() {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        
        // een wijziging

        // api/users/2
        [HttpGet("{id}")]
        public async Task <ActionResult<AppUser>> GetUser(int id) {
            var user = await _context.Users.FindAsync(id);
            //if (user == null)       // return null geeft 204
            //    return Ok(new {});  // 200, {}
            return user;
        }
    }
}