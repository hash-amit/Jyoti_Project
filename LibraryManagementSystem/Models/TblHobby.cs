using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class TblHobby
    {
        [Key]
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
    }
}