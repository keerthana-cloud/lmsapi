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
    public class BooksListController : ControllerBase
    {
        private readonly BooksListContext _context;

        public BooksListController(BooksListContext context)
        {
            _context = context;
        }

        // GET: api/BooksList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksList>>> GetBooksLists()
        {
            return await _context.BooksLists.ToListAsync();
        }

        // GET: api/BooksList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksList>> GetBooksList(int id)
        {
            var booksList = await _context.BooksLists.FindAsync(id);

            if (booksList == null)
            {
                return NotFound();
            }

            return booksList;
        }

        // PUT: api/BooksList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooksList(int id, BooksList booksList)
        {
            if (id != booksList.BooksListId)
            {
                return BadRequest();
            }

            _context.Entry(booksList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksListExists(id))
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

        // POST: api/BooksList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BooksList>> PostBooksList(BooksList booksList)
        {
            
            _context.BooksLists.Add(booksList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooksList", new { id = booksList.BooksListId }, booksList);
        }

        // DELETE: api/BooksList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooksList(int id)
        {
            var booksList = await _context.BooksLists.FindAsync(id);
            if (booksList == null)
            {
                return NotFound();
            }

            _context.BooksLists.Remove(booksList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksListExists(int id)
        {
            return _context.BooksLists.Any(e => e.BooksListId == id);
        }
    }
}
