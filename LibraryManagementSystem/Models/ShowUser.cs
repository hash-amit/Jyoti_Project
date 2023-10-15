using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class ShowUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string Hobby { get; set; }
        public string Pass { get; set; }
    }
}