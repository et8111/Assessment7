using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace QLHOLIDAYPARTY.Models
{

    public class GoT
    {
        [Key]
        public string url { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string culture { get; set; }
        public string born { get; set; }
        public string died { get; set; }
        public string[] titles { get; set; }
        public string[] aliases { get; set; }
        public string father { get; set; }
        public string mother { get; set; }
        public string spouse { get; set; }
        public object[] allegiances { get; set; }
        public string[] books { get; set; }
        public object[] povBooks { get; set; }
        public string[] tvSeries { get; set; }
        public string[] playedBy { get; set; }
        const string useragent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
        public PartyDBEntities1 partyDb;


        public GoT CharacterTest(int number)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"https://www.anapioficeandfire.com/api/characters/" + number);
            request.UserAgent = useragent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (data == "null")
                    return null;
                string data1 = data.Substring(1, data.Length - 2);
                JObject dataObject = JObject.Parse(data);
                var mTemp = dataObject.ToObject<GoT>();
                return mTemp;
            }
            return null;
        }

        public static List<GoT> CharacterTest2(int item)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"https://www.anapioficeandfire.com/api/characters?page="+ item+"&pageSize=10");
            request.UserAgent = useragent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (data == "null")
                    return null;
                string data1 = data.Substring(1, data.Length - 2);
                JArray dataObject = JArray.Parse(data);
                var mTemp = dataObject.ToObject<List<GoT>>();
                return mTemp;
            }
            return null;
        }


        public List<GoT> CharacterList()
        {
            PartyDBEntities1 e = new PartyDBEntities1();
            List<GoT> list = new List<GoT>();
            GoT g = new GoT();
            foreach (var v in e.mytables.Distinct().ToList())
            {
                g.url = v.url;
                g.born = v.born;
                g.father = v.father;
                g.mother = v.mother;
                g.name = v.name;
                g.culture = v.culture;
                g.aliases = v.aliases.Split( ' ');
                g.died = v.died;
                g.playedBy = v.playedBy.Split(' ');
                g.gender = v.gender;
                g.spouse = g.spouse;
                g.titles = v.titles.Split(' ');
                g.tvSeries =v.tvSeries.Split(' ');
                list.Add(g);
                g = new GoT();
            }
            return list;
        }

        public PartyDBEntities1 Selector()
        {
            return new PartyDBEntities1();
        }

        public static mytable GoTToMytable(GoT g)
        {
            var m = new mytable
            {
                name = g.name,
                aliases = string.Join(" ", g.aliases),
                playedBy = string.Join(" ", g.playedBy),
                titles = string.Join(" ", g.titles),
                tvSeries = string.Join(" ", g.tvSeries),
                url = g.url,
                books = string.Join(" ", g.books),
                born = g.born,
                culture = g.culture,
                died = g.died,
                father = g.father,
                gender = g.gender,
                mother = g.mother,
                spouse = string.Join(" ", g.spouse)
            };
            return m;
        }
    }
}