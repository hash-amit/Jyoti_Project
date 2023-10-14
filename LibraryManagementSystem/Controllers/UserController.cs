using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext dc = new DatabaseContext();
        public ActionResult AddUser()
        {
            TblUser1 tblUser1 = new TblUser1();
            tblUser1.LstCountry = (from _country in dc.Countries
                                   select _country).ToList();
            tblUser1.LstState = (from _state in dc.States
                                 select _state).ToList();
            tblUser1.LstGender = (from _gender in dc.Genders
                                  select _gender).ToList();
            return View("AddUser", tblUser1);
        }

        public JsonResult FetchState(int cid)
        {
            var data = (from _state in dc.States
                        where _state.CountryId == cid
                        select  _state).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertUpdate(TblUser1 usr1)
        {
            TblUser usr = new TblUser();
            usr.Name = usr1.Name;
            usr.Email = usr1.Email;
            usr.Country = usr1.Country;
            usr.State = usr1.State;
            usr.Gender = usr1.Gender;
            usr.Pass = usr1.Pass;
            dc.Users.Add(usr);
            dc.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            List<TblUser> usrList = (from tbl in dc.Users
                        select tbl).ToList();
            return View("Show", usrList);
        }
    }
}