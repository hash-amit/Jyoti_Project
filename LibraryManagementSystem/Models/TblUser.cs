using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class TblUser
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int Gender { get; set; }
        public int Hobby { get; set; }
        public string Pass { get; set; }
    }
}