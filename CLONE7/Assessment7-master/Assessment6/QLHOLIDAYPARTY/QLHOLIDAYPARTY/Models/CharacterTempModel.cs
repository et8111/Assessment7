using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace QLHOLIDAYPARTY.Models
{

    public class GoT
    {
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

        public GoT CharacterTest2(string item)
        {
            HttpWebRequest request = WebRequest.CreateHttp(item);
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


        public List<GoT> CharacterList()
        {
            PartyDBEntities1 e = new PartyDBEntities1();
            List<GoT> list = new List<GoT>();
            GoT g = new GoT();
            foreach (var v in e.mytables.ToList())
            {
                g.url = v.url;
                g.born = v.born;
                g.born = null;
                g.father = v.father;
                g.mother = v.mother;
                g.name = v.name;
                g.culture = v.culture;
                g.aliases = null;
                g.died = null;
                g.playedBy = null;
                g.gender = null;
                g.spouse = null;
                g.titles = null;
                g.tvSeries = null;
                list.Add(g);
                g = new GoT();
            }
            return list;
        }

        public PartyDBEntities1 Selector()
        {
            return new PartyDBEntities1();
        }
    }
}