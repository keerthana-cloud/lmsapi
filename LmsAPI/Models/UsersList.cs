using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LmsAPI.Models
{
    public class UsersList
    {
        [Key]
        public int UsersListId { get; set; }


        [Column(TypeName = "nvarchar(320)")] 
        public string UserEmail { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string UserPassword { get; set; }
    }
}
