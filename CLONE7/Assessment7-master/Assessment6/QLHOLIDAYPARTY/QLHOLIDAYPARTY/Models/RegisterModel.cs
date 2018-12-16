using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHOLIDAYPARTY.Models
{
    public class RegisterModel : IdentityUser
    {
        public RegisterModel()
        {
            g = new Guest();
            d = new Dish();
        }
        public RegisterModel(string userName)
        {
            UserName = userName;
            g = new Guest();
            d = new Dish();
        }
        public Dish d { get; set; }
        public Guest g { get; set; }
        public string Password {get; set;}
    }
}