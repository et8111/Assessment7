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
            List<GoT> list = new List<GoT>();
            GoT g = new GoT();
            list = g.CharacterList();
            g = list.FirstOrDefault(a => a.name == url);
            return View(g);
        }
    }
}




//string[] Targaryen =
//{
//    "https://www.anapioficeandfire.com/api/characters/33",
//    "https://www.anapioficeandfire.com/api/characters/42",
//    "https://www.anapioficeandfire.com/api/characters/43",
//    "https://www.anapioficeandfire.com/api/characters/44",
//    "https://www.anapioficeandfire.com/api/characters/45",
//    "https://www.anapioficeandfire.com/api/characters/48",
//    "https://www.anapioficeandfire.com/api/characters/49",
//    "https://www.anapioficeandfire.com/api/characters/55",
//    "https://www.anapioficeandfire.com/api/characters/58",
//    "https://www.anapioficeandfire.com/api/characters/59",
//    "https://www.anapioficeandfire.com/api/characters/76",
//    "https://www.anapioficeandfire.com/api/characters/91",
//    "https://www.anapioficeandfire.com/api/characters/93",
//    "https://www.anapioficeandfire.com/api/characters/109",
//    "https://www.anapioficeandfire.com/api/characters/110",
//    "https://www.anapioficeandfire.com/api/characters/154",
//    "https://www.anapioficeandfire.com/api/characters/155",
//    "https://www.anapioficeandfire.com/api/characters/156",
//    "https://www.anapioficeandfire.com/api/characters/157",
//    "https://www.anapioficeandfire.com/api/characters/161",
//    "https://www.anapioficeandfire.com/api/characters/168",
//    "https://www.anapioficeandfire.com/api/characters/169",
//    "https://www.anapioficeandfire.com/api/characters/195",
//    "https://www.anapioficeandfire.com/api/characters/239",
//    "https://www.anapioficeandfire.com/api/characters/265",
//    "https://www.anapioficeandfire.com/api/characters/266",
//    "https://www.anapioficeandfire.com/api/characters/269",
//    "https://www.anapioficeandfire.com/api/characters/270",
//    "https://www.anapioficeandfire.com/api/characters/271",
//    "https://www.anapioficeandfire.com/api/characters/272",
//    "https://www.anapioficeandfire.com/api/characters/275",
//    "https://www.anapioficeandfire.com/api/characters/276",
//    "https://www.anapioficeandfire.com/api/characters/330",
//    "https://www.anapioficeandfire.com/api/characters/334",
//    "https://www.anapioficeandfire.com/api/characters/361",
//    "https://www.anapioficeandfire.com/api/characters/488",
//    "https://www.anapioficeandfire.com/api/characters/546",
//    "https://www.anapioficeandfire.com/api/characters/560",
//    "https://www.anapioficeandfire.com/api/characters/576",
//    "https://www.anapioficeandfire.com/api/characters/610",
//    "https://www.anapioficeandfire.com/api/characters/611",
//    "https://www.anapioficeandfire.com/api/characters/696",
//    "https://www.anapioficeandfire.com/api/characters/709",
//    "https://www.anapioficeandfire.com/api/characters/729",
//    "https://www.anapioficeandfire.com/api/characters/759",
//    "https://www.anapioficeandfire.com/api/characters/767",
//    "https://www.anapioficeandfire.com/api/characters/779",
//    "https://www.anapioficeandfire.com/api/characters/797",
//    "https://www.anapioficeandfire.com/api/characters/865",
//    "https://www.anapioficeandfire.com/api/characters/867",
//    "https://www.anapioficeandfire.com/api/characters/868",
//    "https://www.anapioficeandfire.com/api/characters/869",
//    "https://www.anapioficeandfire.com/api/characters/870",
//    "https://www.anapioficeandfire.com/api/characters/871",
//    "https://www.anapioficeandfire.com/api/characters/872",
//    "https://www.anapioficeandfire.com/api/characters/873",
//    "https://www.anapioficeandfire.com/api/characters/874",
//    "https://www.anapioficeandfire.com/api/characters/875",
//    "https://www.anapioficeandfire.com/api/characters/876",
//    "https://www.anapioficeandfire.com/api/characters/951",
//    "https://www.anapioficeandfire.com/api/characters/971",
//    "https://www.anapioficeandfire.com/api/characters/1067",
//    "https://www.anapioficeandfire.com/api/characters/1070",
//    "https://www.anapioficeandfire.com/api/characters/1079",
//    "https://www.anapioficeandfire.com/api/characters/1114",
//    "https://www.anapioficeandfire.com/api/characters/1142",
//    "https://www.anapioficeandfire.com/api/characters/1205",
//    "https://www.anapioficeandfire.com/api/characters/1242",
//    "https://www.anapioficeandfire.com/api/characters/1302",
//    "https://www.anapioficeandfire.com/api/characters/1303",
//    "https://www.anapioficeandfire.com/api/characters/1340",
//    "https://www.anapioficeandfire.com/api/characters/1358",
//    "https://www.anapioficeandfire.com/api/characters/1445",
//    "https://www.anapioficeandfire.com/api/characters/1450",
//    "https://www.anapioficeandfire.com/api/characters/1469",
//    "https://www.anapioficeandfire.com/api/characters/1520",
//    "https://www.anapioficeandfire.com/api/characters/1523",
//    "https://www.anapioficeandfire.com/api/characters/1527",
//    "https://www.anapioficeandfire.com/api/characters/1528",
//    "https://www.anapioficeandfire.com/api/characters/1548",
//    "https://www.anapioficeandfire.com/api/characters/1549",
//    "https://www.anapioficeandfire.com/api/characters/1560",
//    "https://www.anapioficeandfire.com/api/characters/1589",
//    "https://www.anapioficeandfire.com/api/characters/1608",
//    "https://www.anapioficeandfire.com/api/characters/1709",
//    "https://www.anapioficeandfire.com/api/characters/1739",
//    "https://www.anapioficeandfire.com/api/characters/1826",
//    "https://www.anapioficeandfire.com/api/characters/1856",
//    "https://www.anapioficeandfire.com/api/characters/1867",
//    "https://www.anapioficeandfire.com/api/characters/1872",
//    "https://www.anapioficeandfire.com/api/characters/1873",
//    "https://www.anapioficeandfire.com/api/characters/1874",
//    "https://www.anapioficeandfire.com/api/characters/1897",
//    "https://www.anapioficeandfire.com/api/characters/1944",
//    "https://www.anapioficeandfire.com/api/characters/1948",
//    "https://www.anapioficeandfire.com/api/characters/1978",
//    "https://www.anapioficeandfire.com/api/characters/1981",
//    "https://www.anapioficeandfire.com/api/characters/2071",
//    "https://www.anapioficeandfire.com/api/characters/2086",
//    "https://www.anapioficeandfire.com/api/characters/2124",
//    "https://www.anapioficeandfire.com/api/characters/2128"
//};
//GoT temp = new GoT();
//foreach (var v in Targaryen)
//{
//    gotList.Add(temp.CharacterTest2(v));
//}
//PartyDBEntities1 e = new PartyDBEntities1();

//mytable g = new mytable();
//foreach (var v in gotList)
//{
//    g.url = v.url;
//    g.born = v.born;
//    g.born = null;
//    g.father = v.father;
//    g.mother = v.mother;
//    g.name = v.name;
//    g.culture = v.culture;
//    g.aliases = null;
//    g.died = null;
//    g.playedBy = null;
//    g.gender = null;
//    g.spouse = null;
//    g.titles = null;
//    g.tvSeries = null;
//    e.mytables.Add(g);
//    g = new mytable();
//    e.SaveChanges();
//}