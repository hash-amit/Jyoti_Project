using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class TblUser1
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Country { get; set; }
        public List<TblCountry> LstCountry { get; set; }
        public int State { get; set; }
        public List<TblState> LstState { get; set; }
        public int Gender { get; set; }
        public List<TblGender> LstGender { get; set; }
        public string Hobby { get; set; }
        public List<TblHobby1> LstHobby { get; set; }
        public string Pass { get; set; }
    }
}