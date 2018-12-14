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
        { }
        public RegisterModel(string userName)
        {
            UserName = userName;
        }

        public string Password {get; set;}
    }
}