using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class TblCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}