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
            var g = new GoT();
            g = g.CharacterTest(1);
            return View();
        }

        public ActionResult Dish()
        {
            var j = new PartyDBEntities1();
            var model = new RegisterModel();
            model.g = j.Guests.Find(User.Identity.Name);
            var temp = j.Guests.ToList();
            model.d = j.Dishes.ToList().FirstOrDefault(a => a.PersonName == (model.g.FirstName + " " + model.g.LastName));
            if(model.d == null)
                model.d = new Dish();
            return View(model);
        }
        public ActionResult Done()
        {
            string temp = TempData["1"].ToString();
            PartyDBEntities1 j = new PartyDBEntities1();
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
            PartyDBEntities1 j = new PartyDBEntities1();
            RegisterModel model = new RegisterModel();
            model.g = j.Guests.Find(User.Identity.Name);
            model.d = j.Dishes.FirstOrDefault(a => a.PersonName == (model.g.FirstName + " " + model.g.LastName));
            if (model.d == null)
            {
                model.d = new Dish();
                model.d.PersonName = "No Dish";
            }

            return View(model);
        }

        public ActionResult dishEditor(int id)
        {
            PartyDBEntities1 p = new PartyDBEntities1();
            Dish d = p.Dishes.Find(id);

            return View(d);
        }

        public ActionResult dishSaver(Dish d)
        {
            PartyDBEntities1 p = new PartyDBEntities1();
            Dish oldie = p.Dishes.Find(d.DishID);
            if (oldie == null)
            {
                p.Dishes.Add(d);
            }
            else
            {
                oldie.DishDescription = d.DishDescription;
                oldie.DishName = d.DishName;
                oldie.Options = d.Options;
                oldie.PersonName = d.PersonName;
                oldie.PhoneNumber = d.PhoneNumber;
                p.Entry(oldie).State = System.Data.Entity.EntityState.Modified;
            }
            p.SaveChanges();
            TempData["dish"] = d;
            return RedirectToAction("Done1", "Home");
        }

        public ActionResult DELETEDISH(int id)
        {
            PartyDBEntities1 p = new PartyDBEntities1();
            Dish d = p.Dishes.Find(id);

            p.Dishes.Remove(d);
            p.SaveChanges();

            return RedirectToAction("dishDisplay");
        }

        public ActionResult displayGuest()
        {
            GoT temp = new GoT();
            temp.partyDb = temp.Selector();
            return View(temp);
        }

        [HttpPost]
        public ActionResult displayGuest(GoT g)
        {
            PartyDBEntities1 p = new PartyDBEntities1();
            Guest old = p.Guests.Find(User.Identity.Name);
            GoT got = new GoT();
            old.GoTCharacter = got.CharacterList().Where(a => a.url == g.url).Select(b => b.name).FirstOrDefault();
            old.url = g.url;
            p.Entry(old).State = System.Data.Entity.EntityState.Modified;
            p.SaveChanges();
            GoT temp = new GoT();
            temp.partyDb = temp.Selector();
            return View(temp);
        }

        public ActionResult DELETEGUEST(int id)
        {
            PartyDBEntities1 p = new PartyDBEntities1();
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