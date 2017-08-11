using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;


namespace MTGProcessAllOneFile
{
    public class ProcessBigMTGJSON
    {
        List<string> lTypes = new List<string>();
        List<string> lSubTypes = new List<string>();
        List<string> lPrintings = new List<string>();
        List<string> lLegalities = new List<string>();
        List<string> lColors = new List<string>();
        List<string> lColorIdentities = new List<string>();
        List<ForeignNames> lForeignNames = new List<ForeignNames>();

        List<Set> lSets = new List<Set>();
        
        public void ProcessTheJson()
        {
            string json;
            using (StreamReader file = File.OpenText(@"D:\projects\MTG\MTGJSON.com\AllOneFile\AllSets-x.json"))
            {
                json = file.ReadToEnd();
            }

            // this is the whole json file here
            JObject o = JObject.Parse(json);
            string setCode = "";

            #region MainLoop
            foreach (var obj in o)
            {
                setCode = obj.Key;
                
                JToken setInfo = obj.Value;
                ProcessSets(setInfo);
                JToken jtCards = setInfo.SelectToken("cards");
                //set.releaseDate = setInfo.SelectToken("releaseDate").ToString();
                //set.name = setInfo.SelectToken("name").ToString();
                //set.code = setInfo.SelectToken("code").ToString();
                //if (setInfo.SelectToken("oldCode") != null) { set.oldCode = setInfo.SelectToken("oldCode").ToString(); }
                //if (setInfo.SelectToken("magicCardsInfoCode") != null) { set.magicCardsInfoCode = setInfo.SelectToken("magicCardsInfoCode").ToString(); }
                //set.border = setInfo.SelectToken("border").ToString();
                //set.type = setInfo.SelectToken("type").ToString();
                //if (setInfo.SelectToken("mkm_name") != null) { set.mkm_name = setInfo.SelectToken("mkm_name").ToString(); }
                //if (setInfo.SelectToken("mkm_id") != null) { set.mkm_id = setInfo.SelectToken("mkm_id").ToString(); }
                //if (setInfo.SelectToken("magicRaritiesCodes") != null) { set.magicRaritiesCodes = setInfo.SelectToken("magicRaritiesCodes").ToString(); }
                //if (setInfo.SelectToken("onlineOnly") != null) { set.onlineOnly = setInfo.SelectToken("onlineOnly").ToString(); }
                //if (setInfo.SelectToken("translations") != null) { set.translations = setInfo.SelectToken("translations").ToString(); }
                //if (setInfo.SelectToken("booster") != null) { set.booster = setInfo.SelectToken("booster").ToString(); }

                //if (set.booster != null) { Console.WriteLine(string.Format("booster - {0}", set.booster)); }


                var cardsProperties = jtCards.Children();
                //Console.WriteLine(string.Format("set {0}", set.name));
                foreach (var prop in cardsProperties)
                {
                    ProcessCardTokens(prop);
                }

                //Console.WriteLine(jtCode.ToString());

                //List<Card> crds = (Cards)cards;

                // now process cards per set
                //foreach (var card in (Cards)cards)
                //{
                //    Console.WriteLine(string.Format("{0} - {1} - {2}", card.name, card.cmc, setCode));
                //}

            }

            #endregion

            Console.WriteLine("...all done for now");
            Console.ReadLine();
        }


        private void ProcessSets(JToken setInfo)
        {
            Set set = new Set();
            set.releaseDate = setInfo.SelectToken("releaseDate").ToString();
            set.name = setInfo.SelectToken("name").ToString();
            set.code = setInfo.SelectToken("code").ToString();
            if (setInfo.SelectToken("oldCode") != null) { set.oldCode = setInfo.SelectToken("oldCode").ToString(); }
            if (setInfo.SelectToken("magicCardsInfoCode") != null) { set.magicCardsInfoCode = setInfo.SelectToken("magicCardsInfoCode").ToString(); }
            set.border = setInfo.SelectToken("border").ToString();
            set.type = setInfo.SelectToken("type").ToString();
            if (setInfo.SelectToken("mkm_name") != null) { set.mkm_name = setInfo.SelectToken("mkm_name").ToString(); }
            if (setInfo.SelectToken("mkm_id") != null) { set.mkm_id = setInfo.SelectToken("mkm_id").ToString(); }
            if (setInfo.SelectToken("magicRaritiesCodes") != null) { set.magicRaritiesCodes = setInfo.SelectToken("magicRaritiesCodes").ToString(); }
            if (setInfo.SelectToken("onlineOnly") != null) { set.onlineOnly = setInfo.SelectToken("onlineOnly").ToString(); }
            if (setInfo.SelectToken("translations") != null) { set.translations = setInfo.SelectToken("translations").ToString(); }
            //if (setInfo.SelectToken("booster") != null) { set.booster = setInfo.SelectToken("booster").ToString(); }

            //if (set.booster != null) { Console.WriteLine(string.Format("booster - {0}", set.booster)); }
            lSets.Add(set);
        }

        private void ProcessCardTokens(JToken jtoken)
        {
            var allPropsInList = jtoken.ToList();

            var multiverseid = jtoken.SelectToken("multiverseid");
            var artist = jtoken.SelectToken("artist");
            var cmc = jtoken.SelectToken("cmc");
            var flavor = jtoken.SelectToken("flavor");
            var id = jtoken.SelectToken("id");
            var imageName = jtoken.SelectToken("imageName");
            var layout = jtoken.SelectToken("layout");
            var manaCost = jtoken.SelectToken("manaCost");
            var mciNumber = jtoken.SelectToken("mciNumber");
            var name = jtoken.SelectToken("name");
            var number = jtoken.SelectToken("number");
            var originalText = jtoken.SelectToken("originalText");
            var originalType = jtoken.SelectToken("originalType");
            var power = jtoken.SelectToken("power");
            var rarity = jtoken.SelectToken("rarity");
            var text = jtoken.SelectToken("text");
            var toughness = jtoken.SelectToken("toughness");
            var type = jtoken.SelectToken("type");
            Console.WriteLine(string.Format("{0} - (1)", multiverseid, name));
            //
            // array objects
            var t = jtoken.SelectToken("types");
            var s = jtoken.SelectToken("subtypes");
            var p = jtoken.SelectToken("printings");
            var l = jtoken.SelectToken("Legality");
            var fn = jtoken.SelectToken("foreignNames");
            var c = jtoken.SelectToken("colors");
            var ci = jtoken.SelectToken("colorIdentity");

            // this will file base lookup tables
            if (t != null)
            {
                foreach (var typ in t)
                {  if (!lTypes.Contains(typ.ToString())) { lTypes.Add(typ.ToString()); }  }
            }
            if (s != null)
            {
                foreach (var subtyp in s)
                {  if (!lSubTypes.Contains(subtyp.ToString())) { lSubTypes.Add(subtyp.ToString()); }  }
            }
            if (p != null)
            {
                foreach (var print in p)
                {  if (!lPrintings.Contains(print.ToString())) { lPrintings.Add(print.ToString()); }   }
            }
            if (l != null)
            {
                foreach (var legal in l)
                { if (!lLegalities.Contains(legal.ToString())) { lLegalities.Add(legal.ToString()); } }
            }
            if (c != null)
            {
                foreach (var color in c)
                { if (!lColors.Contains(color.ToString())) { lColors.Add(color.ToString()); } }
            }
            if (ci != null)
            {
                foreach (var colorident in ci)
                { if (!lColorIdentities.Contains(colorident.ToString())) { lColorIdentities.Add(colorident.ToString()); } }
            }
            if (fn != null)
            {
                Console.WriteLine(string.Format( "todo: foreignNames {0}",fn.ToString(), ConsoleColor.Red));
            }
        }
    }
}
