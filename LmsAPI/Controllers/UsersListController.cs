using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmsAPI.Models;

namespace LmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersListController : ControllerBase
    {
        private readonly BooksListContext _context;

        public UsersListController(BooksListContext context)
        {
            _context = context;
        }

        // GET: api/UsersList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersList>>> GetUsersLists()
        {
            return await _context.UsersLists.ToListAsync();
        }

        // GET: api/UsersList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersList>> GetUsersList(int id)
        {
            var usersList = await _context.UsersLists.FindAsync(id);

            if (usersList == null)
            {
                return NotFound();
            }

            return usersList;
        }

        // PUT: api/UsersList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersList(int id, UsersList usersList)
        {
            if (id != usersList.UsersListId)
            {
                return BadRequest();
            }

            _context.Entry(usersList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersListExists(id))
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

        // POST: api/UsersList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersList>> PostUsersList(UsersList usersList)
        {
            _context.UsersLists.Add(usersList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersList", new { id = usersList.UsersListId }, usersList);
        }

        // DELETE: api/UsersList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersList(int id)
        {
            var usersList = await _context.UsersLists.FindAsync(id);
            if (usersList == null)
            {
                return NotFound();
            }

            _context.UsersLists.Remove(usersList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersListExists(int id)
        {
            return _context.UsersLists.Any(e => e.UsersListId == id);
        }
    }
}
