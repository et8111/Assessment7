using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHOLIDAYPARTY.Models;

namespace QLHOLIDAYPARTY.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RSVP()
        {
            return View(new Guest());
        }

        public ActionResult Dish()
        {
            return View(new Dish());
        }

        public ActionResult Done(Guest g)
        {
            JordanPartyDbEntities p = new JordanPartyDbEntities();
            p.Guests.Add(g);
            p.SaveChanges();
            return View(g);
        }
        public ActionResult Done1(Dish d)
        {
            JordanPartyDbEntities p = new JordanPartyDbEntities();
            p.Dishes.Add(d);
            p.SaveChanges();
            return View(d);
        }

        public ActionResult dishDisplay()
        {
            return View(new JordanPartyDbEntities());
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

            p.Entry(oldie).State = System.Data.EntityState.Modified;
            p.SaveChanges();

            return RedirectToAction("dishDisplay");
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
    }
}