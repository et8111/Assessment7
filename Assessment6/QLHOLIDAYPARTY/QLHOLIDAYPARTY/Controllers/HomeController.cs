using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHOLIDAYPARTY

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
            JordanPartyDbEntities1 p = new JordanPartyDbEntities1();
            p.Guests.Add(g);
            p.SaveChanges();
            return View(g);
        }
        public ActionResult Done1(Dish d)
        {
            JordanPartyDbEntities1 p = new JordanPartyDbEntities1();
            p.Dishes.Add(d);
            p.SaveChanges();
            return View(d);
        }

        public ActionResult dishDisplay()
        {
            return View(new JordanPartyDbEntities1());
        }

        public ActionResult dishEditor(int id)
        {
            JordanPartyDbEntities1 p = new JordanPartyDbEntities1();
            Dish d = p.Dishes.Find(id);

            return View(d);
        }

        public ActionResult dishSaver(Dish d)
        {
            JordanPartyDbEntities1 p = new JordanPartyDbEntities1();
            Dish oldie = p.Dishes.Find(d.DishID);
            oldie.DishDescription = d.DishDescription;
            oldie.DishName = d.DishName;
            oldie.Options = d.Options;
            oldie.PersonalName = d.PersonalName;
            oldie.PhoneNumber = d.PhoneNumber;

            p.Entry(oldie).State = System.Data.Entity.EntityState.Modified;
            p.SaveChanges();

            return RedirectToAction("dishDisplay");
        }

        public ActionResult DELETEDISH(int id)
        {
            JordanPartyDbEntities1 p = new JordanPartyDbEntities1();
            Dish d = p.Dishes.Find(id);

            p.Dishes.Remove(d);
            p.SaveChanges();

            return RedirectToAction("dishDisplay");
        }

        public ActionResult displayGuest()
        {
            return View(new JordanPartyDbEntities1());
        }
        public ActionResult DELETEGUEST(int id)
        {
            JordanPartyDbEntities1 p = new JordanPartyDbEntities1();
            Guest d = p.Guests.Find(id);

            p.Guests.Remove(d);
            p.SaveChanges();

            return RedirectToAction("displayGuest");
        }
    }
}