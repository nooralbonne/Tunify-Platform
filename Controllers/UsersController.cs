using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TunifyDbContext _Users;

        public UsersController(TunifyDbContext context)
        {
            _Users = context;
        }

        // GET: api/Users
        [Route("/Users/GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_Users.Users == null)
          {
              return NotFound();
          }
            return await _Users.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_Users.Users == null)
          {
              return NotFound();
          }
            var user = await _Users.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UsersId)
            {
                return BadRequest();
            }

            _Users.Entry(user).State = EntityState.Modified;

            try
            {
                await _Users.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_Users.Users == null)
          {
              return Problem("Entity set 'TunifyDbContext.Users'  is null.");
          }
            _Users.Users.Add(user);
            await _Users.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UsersId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_Users.Users == null)
            {
                return NotFound();
            }
            var user = await _Users.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _Users.Users.Remove(user);
            await _Users.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_Users.Users?.Any(e => e.UsersId == id)).GetValueOrDefault();
        }
    }
}
