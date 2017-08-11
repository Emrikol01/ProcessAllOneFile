using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGProcessAllOneFile
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessBigMTGJSON procBigMTG = new ProcessBigMTGJSON();

            procBigMTG.ProcessTheJson();



            //string json;
            //using (StreamReader file = File.OpenText(@"D:\projects\MTG\MTGJSON.com\AllOneFile\AllSets-x.json"))
            //{
            //    //JsonSerializer serializer = new JsonSerializer();
            //    //Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
            //    //o = serializer.Deserialize(file, typeof(object));
            //    //o = serializer.Deserialize(file, typeof(Newtonsoft.Json.Linq.JObject));
            //    json = file.ReadToEnd();
            //}

            //// base classes to be used in building tables
            //Colors colors = new Colors();
            //ColorIdentities colorIdentities = new ColorIdentities();
            //Legalities legalities = new Legalities();
            //Printings printings = new Printings();
            //Types types = new Types();
            //SubTypes subTypes = new SubTypes();
            //ForeignNames foreignNames = new ForeignNames();

            //List<Colors> colorList = new List<Colors>();
            //List<ColorIdentities> colorIdentitiesList = new List<ColorIdentities>();
            //List<Legalities> legalitiesList = new List<Legalities>();
            //List<Printings> printingsList = new List<Printings>();
            //List<Types> typesList = new List<Types>();
            //List<SubTypes> subTypesList = new List<SubTypes>();
            //List<ForeignNames> foreignNamesList = new List<ForeignNames>();


            //JObject o = JObject.Parse(json);
            //string setCode = "";

            //// an object to hold a set contents, which should also be a list of cards
            //Set _set = new Set();

            //foreach (var obj in o)
            //{
            //    setCode = obj.Key;
            //    JToken setInfo = obj.Value;
            //    JToken jtCards = setInfo.SelectToken("cards");
            //    JToken jtReleaseDate = setInfo.SelectToken("releaseDate");
            //    JToken jtName = setInfo.SelectToken("name");
            //    JToken jtCode = setInfo.SelectToken("code");
            //    JToken jtoldCode = setInfo.SelectToken("oldCode");
            //    JToken jtmagicCardsInfoCode = setInfo.SelectToken("magicCardsInfoCode");
            //    JToken jtborder = setInfo.SelectToken("border");
            //    JToken jttype = setInfo.SelectToken("type");
            //    JToken jtmkm_name = setInfo.SelectToken("mkm_name");
            //    JToken jtmkm_id = setInfo.SelectToken("mkm_id");
            //    JToken jtmagicRaritiesCodes = setInfo.SelectToken("magicRaritiesCodes");
            //    JToken jtonlineOnly = setInfo.SelectToken("onlineOnly");
            //    JToken jttranslations = setInfo.SelectToken("translations");
            //    JToken jtbooster = setInfo.SelectToken("booster");
   
            //    if (jtbooster != null) { Console.WriteLine(string.Format("booster - {0}", jtName.ToString())); }


            //    var cardsProperties = jtCards.Children();
            //    foreach (var cProp in cardsProperties)
            //    {
            //        ProcessCardTokens(cProp);
            //    }


            //    //foreach (var item in jtCards.Children())
            //    //{
            //    //    var itemProperties = item.Children<JProperty>();

            //    //    //you could do a foreach or a linq here depending on what you need to do exactly with the value
            //    //    var myElement = itemProperties.FirstOrDefault(x => x.Name == "multiverseid");
            //    //    var myElementValue = myElement.Value; ////This is a JValue type
            //    //}




            //    //Console.WriteLine(string.Format("{0} - {1} - {2} : total cards {3}",jtName.ToString(), jtCode.ToString(), jtReleaseDate.ToString(), _set.cards.Count.ToString()));

            //    //Console.WriteLine(jtCode.ToString());

            //    //List<Card> crds = (Cards)cards;

            //    // now process cards per set
            //    //foreach (var card in (Cards)cards)
            //    //{
            //    //    Console.WriteLine(string.Format("{0} - {1} - {2}", card.name, card.cmc, setCode));
            //    //}

            //}
            Console.Read();
        }

        public static void ProcessCardTokens(JToken jtoken)
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
            //
            // array objects
            var t = jtoken.SelectToken("types");
            var s = jtoken.SelectToken("subtypes");
            var p = jtoken.SelectToken("printings");
            var l = jtoken.SelectToken("Legality");
            var fn = jtoken.SelectToken("foreignNames");
            var c = jtoken.SelectToken("colors");
            var ci = jtoken.SelectToken("colorIdentity");

            if (t != null)
            {
                foreach (var typ in t)
                {
                    Console.WriteLine(string.Format("add to type {0}", typ.ToString()));
                }
            }
            if (s != null)
            {
                foreach (var subtyp in s)
                {
                    Console.WriteLine(string.Format("add to subtype {0}", subtyp.ToString()));
                }
            }

            Console.WriteLine(string.Format("{0} - {1}", name.ToString(), multiverseid.ToString()));

            Console.WriteLine(jtoken.ToString());
        }
    }
}
