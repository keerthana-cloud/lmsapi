using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsAPI.Models
{
    public class BooksListContext:DbContext
    {
        public BooksListContext(DbContextOptions<BooksListContext> options):base(options)
        {

        }
        public DbSet<BooksList> BooksLists { get; set; }
        public DbSet<UsersList> UsersLists { get; set; }
       
    }
}
