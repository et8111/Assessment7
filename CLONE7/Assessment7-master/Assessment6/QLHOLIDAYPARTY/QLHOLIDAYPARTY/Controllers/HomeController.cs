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
        public UserManager<RegisterModel> UserManager => HttpContext.GetOwinContext().Get<UserManager<RegisterModel>>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RSVP()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult RSVP(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().Get<UserManager<RegisterModel>>();
                var id = UserManager.Create(new RegisterModel(model.g.EmailAddress), model.Password);
                if (id.Succeeded)
                {
                    JordanPartyDbEntities p = new JordanPartyDbEntities();
                    p.Guests.Add(model.g);
                    p.SaveChanges();
                    TempData["1"] = model.g.EmailAddress;
                    return RedirectToAction("Done", "Home");
                }
                ModelState.AddModelError("", id.Errors.FirstOrDefault());
            }
            ModelState.AddModelError("","Idiot");
            return View(model);
        }

        public ActionResult Dish()
        {
            return View(new Dish());
        }
        public ActionResult Done()
        {
            string temp = TempData["1"].ToString();
            JordanPartyDbEntities j = new JordanPartyDbEntities();
            RegisterModel regi = new RegisterModel();
            var tempGuest = j.Guests.Where(a => a.EmailAddress == temp).ToList();

            regi.g.FirstName = tempGuest.FirstName;
            regi.g.LastName = tempGuest.LastName;
            regi.g.EmailAddress = tempGuest.EmailAddress;
            regi.g.AttendanceDate = tempGuest.AttendanceDate;
            regi.g.Guest1 = tempGuest.Guest1;
            return View(regi);
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

            p.Entry(oldie).State = System.Data.Entity.EntityState.Modified;
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