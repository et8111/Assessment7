using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using QLHOLIDAYPARTY.Models;

namespace QLHOLIDAYPARTY.Controllers
{
    public class IdentityController : Controller
    {
        public UserManager<RegisterModel> UserManager => HttpContext.GetOwinContext().Get<UserManager<RegisterModel>>();

        public ActionResult Registration()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().Get<UserManager<RegisterModel>>();
                var id = UserManager.Create(new RegisterModel(model.g.EmailAddress), model.Password);
                if (id.Succeeded)
                {
                    PartyDBEntities1 p = new PartyDBEntities1();
                    p.Guests.Add(model.g);
                    p.SaveChanges();
                    TempData["1"] = model.g.EmailAddress;
                    return RedirectToAction("Done", "Home");
                }
                ModelState.AddModelError("", id.Errors.FirstOrDefault());
            }
            return View(model);
        }

        public ActionResult Login()
        {

            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Login(RegisterModel model)
        {
            if (ModelState.IsValid)
            {  
                var authManager = HttpContext.GetOwinContext().Authentication;
                var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    var ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Idiot");
            return View(model);
        }

        public ActionResult Logout()
        {
            var AM = HttpContext.GetOwinContext().Authentication;
            AM.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> deleteUser(string email)
        {
            PartyDBEntities1 shop = new PartyDBEntities1();
            Guest dedPerson = shop.Guests.Find(email);
            var userEmail = dedPerson.EmailAddress;
            if (userEmail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByNameAsync(dedPerson.EmailAddress);
            if (User.Identity.Name == userEmail)
            {
                var AM = HttpContext.GetOwinContext().Authentication;
                AM.SignOut();
            }
            await UserManager.DeleteAsync(user);

            //////////////////////////////////////////////////////

            shop.Guests.Remove(dedPerson);
            shop.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}