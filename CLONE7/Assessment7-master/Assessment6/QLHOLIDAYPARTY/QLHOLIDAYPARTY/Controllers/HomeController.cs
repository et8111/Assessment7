using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using QLHOLIDAYPARTY.Models;

namespace QLHOLIDAYPARTY.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dish()
        {
            JordanPartyDbEntities j = new JordanPartyDbEntities();
            RegisterModel model = new RegisterModel();
            model.g = j.Guests.Find(User.Identity.Name);
            var temp = j.Guests.ToList();
            model.d = j.Dishes.ToList().FirstOrDefault(a => a.PersonalName == (model.g.FirstName + " " + model.g.LastName));
            if (model.d == null)
                model.d = new Dish();
            return View(model);
        }
        public ActionResult Done()
        {
            string temp = TempData["1"].ToString();
            JordanPartyDbEntities j = new JordanPartyDbEntities();
            RegisterModel regi = new RegisterModel();
            var tempGuest = j.Guests.ToList();

            foreach(var v in tempGuest)
            {
                if(v.EmailAddress == temp)
                {
                    regi.g.EmailAddress = v.EmailAddress;
                    regi.g.FirstName = v.FirstName;
                    regi.g.LastName = v.LastName;
                    regi.g.AttendanceDate = v.AttendanceDate;
                    regi.g.Guest1 = v.Guest1;
                }
            }
            return View(regi);
        }
        public ActionResult Done1()
        {
            Dish d = (Dish)TempData["dish"];
            return View(d);
        }

        public ActionResult dishDisplay()
        {
            JordanPartyDbEntities j = new JordanPartyDbEntities();
            RegisterModel model = new RegisterModel();
            model.g = j.Guests.Find(User.Identity.Name);
            model.d = j.Dishes.FirstOrDefault(a => a.PersonalName == (model.g.FirstName + " " + model.g.LastName));
            if (model.d == null)
            {
                model.d = new Dish();
                model.d.PersonalName = "No Dish";
            }

            return View(model);
        }

        public ActionResult dishEditor(int id)
        {
            JordanPartyDbEntities p = new JordanPartyDbEntities();
            Dish d = p.Dishes.Find(id);

            return View(d);
        }

        public ActionResult dishSaver(Dish d)
        {
            JordanPartyDbEntities p = new JordanPartyDbEntities();
            Dish oldie = p.Dishes.Find(d.DishID);
            oldie.DishDescription = d.DishDescription;
            oldie.DishName = d.DishName;
            oldie.Options = d.Options;
            oldie.PersonalName = d.PersonalName;
            oldie.PhoneNumber = d.PhoneNumber;

            p.Entry(oldie).State = System.Data.Entity.EntityState.Modified;
            p.SaveChanges();
            TempData["dish"] = d;
            return RedirectToAction("Done1", "Home");
        }

        public ActionResult DELETEDISH(int id)
        {
            JordanPartyDbEntities p = new JordanPartyDbEntities();
            Dish d = p.Dishes.Find(id);

            p.Dishes.Remove(d);
            p.SaveChanges();

            return RedirectToAction("dishDisplay");
        }

        public ActionResult displayGuest()
        {
            return View(new JordanPartyDbEntities());
        }
        public ActionResult DELETEGUEST(int id)
        {
            JordanPartyDbEntities p = new JordanPartyDbEntities();
            Guest d = p.Guests.Find(id);

            p.Guests.Remove(d);
            p.SaveChanges();

            return RedirectToAction("displayGuest");
        }

        public ActionResult RSVP()
        {
            return View(new RegisterModel());
        }

        public string editer()
        {
            return ":(";
        }
    }
}