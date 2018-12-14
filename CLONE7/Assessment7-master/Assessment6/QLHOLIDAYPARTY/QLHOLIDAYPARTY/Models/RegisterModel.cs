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
        }
        public RegisterModel(string userName)
        {
            UserName = userName;
            g = new Guest();
        }
        public Guest g { get; set; }
        public string Password {get; set;}
    }
}