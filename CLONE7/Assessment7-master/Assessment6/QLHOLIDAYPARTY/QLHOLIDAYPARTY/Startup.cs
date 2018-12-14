using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using QLHOLIDAYPARTY.Models;

[assembly: OwinStartup(typeof(QLHOLIDAYPARTY.Startup))]

namespace QLHOLIDAYPARTY
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JordanPartyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            app.CreatePerOwinContext(() => new IdentityDbContext<RegisterModel>(connectionstring));

            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<UserStore<RegisterModel>>((opt, cont) => new UserStore<RegisterModel>(cont.Get<IdentityDbContext<RegisterModel>>()));
            app.CreatePerOwinContext<UserManager<RegisterModel>>((opt, cont) => new UserManager<RegisterModel>(cont.Get<UserStore<RegisterModel>>()));


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Identity/Login"),
            });
        }
    }
}
