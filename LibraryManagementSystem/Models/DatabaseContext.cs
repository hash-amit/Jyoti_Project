using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("con_string") { }
        public DbSet<TblUser> Users { get; set; }
        public DbSet<TblCountry> Countries { get; set; }
        public DbSet<TblState> States { get; set; }
        public DbSet<TblGender> Genders { get; set; }
        public DbSet<TblHobby> Hobbies { get; set;}
    }
}