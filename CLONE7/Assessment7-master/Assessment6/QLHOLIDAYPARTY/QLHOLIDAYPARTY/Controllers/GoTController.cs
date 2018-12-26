using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHOLIDAYPARTY.Models;

namespace QLHOLIDAYPARTY.Controllers
{
    public class GoTController : Controller
    {
        // GET: GoT
        public ActionResult ListView()
        {
            List<GoT> gotList = new List<GoT>();
            GoT g = new GoT();
            gotList = g.CharacterList();
            return View(gotList);
        }

        public ActionResult info(string url)
        {
            GoT g = new GoT();
            g = g.CharacterTest(int.Parse(url.Substring(49)));
            return View(g);
        }
    }
}