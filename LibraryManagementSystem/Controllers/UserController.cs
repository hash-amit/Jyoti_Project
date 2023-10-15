using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext dc = new DatabaseContext();
        public ActionResult AddUser( int id = 0 )
        {
            TblUser1 usr1 = new TblUser1();
            var hdata = (from _hobby in dc.Hobbies
                         select _hobby).ToList();
            usr1.LstHobby = hdata.Select(x => new TblHobby1
            {
                HobbyId = x.HobbyId,
                HobbyName = x.HobbyName,
                IsHobby = false
            }).ToList();
            if (id > 0)
            {
                var data = (from tbl in dc.Users
                            where tbl.UserId == id
                            select tbl).FirstOrDefault();
                usr1.UserId = data.UserId;
                usr1.Name = data.Name;
                usr1.Email = data.Email;
                usr1.Country = data.Country;
                usr1.State = data.State;
                usr1.Gender = data.Gender;
                string[] arr = data.Hobby.Split(',');
                foreach (var i in usr1.LstHobby) 
                {
                    foreach (var j in arr) 
                    {
                        if (i.HobbyName == j) 
                        {
                            i.IsHobby = true;
                        }
                    }
                }
                usr1.Pass = data.Pass;
                usr1.LstState = (from _state in dc.States
                                 where _state.CountryId == usr1.Country
                                 select _state).ToList();
                ViewBag.btnName = "Update";
            }
            usr1.LstCountry = (from _country in dc.Countries
                               select _country).ToList();
            if (usr1.LstState == null)
            {
                usr1.LstState = (from _state in dc.States
                                 select _state).ToList();
            }
            usr1.LstGender = (from _gender in dc.Genders
                              select _gender).ToList();
            return View("AddUser", usr1);
        }
        public JsonResult FetchState(int cid)
        {
            var data = (from _state in dc.States
                        where _state.CountryId == cid
                        select _state).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult InsertUpdate(TblUser1 usr1)
        {
            TblUser usr = new TblUser();
            usr.UserId = usr1.UserId;
            usr.Name = usr1.Name;
            usr.Email = usr1.Email;
            usr.Country = usr1.Country;
            usr.State = usr1.State;
            usr.Gender = usr1.Gender;
            usr.Pass = usr1.Pass;
            string _hobbies = "";
            foreach (var item in usr1.LstHobby)
            {
                if (item.IsHobby == true)
                {
                    _hobbies += item.HobbyName + ",";
                }
            }
            usr.Hobby = _hobbies.TrimEnd(',');
            if (usr1.UserId > 0)
            {
                dc.Entry(usr).State = EntityState.Modified;
            }
            else
            {
                dc.Users.Add(usr);
            }
            dc.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Delete(int id)
        {
            var data = dc.Users.Find(id);
            dc.Users.Remove(data);
            dc.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Show()
        {
            List<ShowUser> usrList = (from tbl in dc.Users
                                      join _country in dc.Countries on tbl.Country equals _country.CountryId
                                      join _state in dc.States on tbl.State equals _state.StateId
                                      join _gender in dc.Genders on tbl.Gender equals _gender.GenderId
                                      select new ShowUser
                                      {
                                          UserId = tbl.UserId,
                                          Name = tbl.Name,
                                          Email = tbl.Email,
                                          Country = _country.CountryName,
                                          State = _state.StateName,
                                          Gender = _gender.GenderName,
                                          Hobby = tbl.Hobby,
                                          Pass = tbl.Pass
                                      }).ToList();
            return View("Show", usrList);
        }
        public ActionResult EditProcess(int id)
        {
            return RedirectToAction("AddUser", new { id = id });
        }
    }
}