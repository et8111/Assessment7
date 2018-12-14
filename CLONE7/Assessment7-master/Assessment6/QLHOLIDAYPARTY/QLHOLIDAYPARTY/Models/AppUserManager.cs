using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHOLIDAYPARTY.Models
{
    public class AppUserManager : UserManager<RegisterModel>
    {
        public AppUserManager(IUserStore<RegisterModel> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<RegisterModel>(context.Get<IdentityDbContext<RegisterModel>>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}