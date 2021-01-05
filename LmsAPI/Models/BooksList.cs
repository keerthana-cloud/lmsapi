using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LmsAPI.Models
{
    public class BooksList
    {
        [Key]
        public int BooksListId { get; set; }
       

        [Column(TypeName ="nvarchar(13)")] //Isbn of a book is 13 digits
        public  string BookIsbn { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BookTitle { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BooksAuthor { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string BookCategory { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BookPublisher { get; set; }
    }
}
