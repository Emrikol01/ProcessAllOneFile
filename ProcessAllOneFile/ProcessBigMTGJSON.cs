using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace MTGProcessAllOneFile
{
    public class ProcessBigMTGJSON
    {
        List<string> lTypes = new List<string>();
        List<string> lSubTypes = new List<string>();
        List<string> lPrintings = new List<string>();
        List<Legality> lLegalities = new List<Legality>();
        List<string> lColors = new List<string>();
        List<string> lColorIdentities = new List<string>();
        List<ForeignName> lForeignNames = new List<ForeignName>();

        List<Set> lSets = new List<Set>();
        List<Card> lCards = new List<Card>();

        MTGDBDataFactory dbFactory = new MTGDBDataFactory();

        public void ProcessTheJson()
        {
            
            string json;
            string jsonPath = @"D:\projects\MTG\MTGJSON.com\AllSetFilesX\MPS-x.json";
            // @"D:\projects\MTG\MTGJSON.com\AllOneFile\AllSets-x.json"
            using (StreamReader file = File.OpenText(jsonPath))
            {
                json = file.ReadToEnd();
            }


            Set myset = JsonConvert.DeserializeObject<Set>(json);



            // this is the whole json file here
            JObject O = JObject.Parse(json);
            //string setCode = "";
            

            Set set = new Set();
            Card card = new Card();
            Type cardtype = new Type();
            SubType cardSubType = new SubType();
            Printing cardPrinting = new Printing();
            Color cardColor = new Color();
            ColorIdentity cardColorIdentity = new ColorIdentity();
            Legality cardLegality = new Legality();

            foreach (var obj in O)
            {
                JToken setInfo = obj.Value;
                set = new Set();
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

                // booster is actually an arrary (where within there can be arrays at various locations - ToDo future work
                if (setInfo.SelectToken("booster") != null) { set.booster = setInfo.SelectToken("booster").ToString(); }

                //if (set.booster != null) { Console.WriteLine(string.Format("booster - {0}", set.booster)); }
                lSets.Add(set);
                dbFactory.InsertSet(set);
                int SetId = dbFactory.GetSetIdByCode(set.code);
                Console.WriteLine(string.Format("set: {0}", SetId.ToString()));

                JToken jtCards = setInfo.SelectToken("cards");
                var cardsProperties = jtCards.Children();
                foreach (var prop in cardsProperties)
                {
                    card = new Card();
                    var multiverseid = prop.SelectToken("multiverseid");
                    //var artist = prop.SelectToken("artist");
                    //var cmc = prop.SelectToken("cmc");
                    //var flavor = prop.SelectToken("flavor");
                    //var id = prop.SelectToken("id");
                    //var imageName = prop.SelectToken("imageName");
                    //var layout = prop.SelectToken("layout");
                    //var manaCost = prop.SelectToken("manaCost");
                    //var mciNumber = prop.SelectToken("mciNumber");
                    //var name = prop.SelectToken("name");
                    //var number = prop.SelectToken("number");
                    //var originalText = prop.SelectToken("originalText");
                    //var originalType = prop.SelectToken("originalType");
                    //var power = prop.SelectToken("power");
                    //var rarity = prop.SelectToken("rarity");
                    //var text = prop.SelectToken("text");
                    //var toughness = prop.SelectToken("toughness");
                    //var type = prop.SelectToken("type");

                    //Console.WriteLine(string.Format("{0} ", multiverseid));

                    //if (multiverseid != null)
                    //{
                    //    card.SetId = SetId;
                    //    card.multiverseid = multiverseid.ToString();
                    //    if (artist != null) { card.artist = artist.ToString(); }
                    //    if (cmc != null) { card.cmc = cmc.ToString(); }
                    //    if (flavor != null) { card.flavor = flavor.ToString(); }
                    //    if (id != null) { card.id = id.ToString(); }
                    //    if (imageName != null) { card.imageName = imageName.ToString(); }
                    //    if (layout != null) { card.layout = layout.ToString(); }
                    //    if (manaCost != null) { card.manaCost = manaCost.ToString(); }
                    //    if (mciNumber != null) { card.mciNumber = mciNumber.ToString(); }
                    //    if (name != null) { card.name = name.ToString(); }
                    //    if (number != null) { card.number = number.ToString(); }
                    //    if (originalText != null) { card.originalText = originalText.ToString(); }
                    //    if (originalType != null) { card.originalType = originalType.ToString(); }
                    //    if (power != null) { card.power = power.ToString(); }
                    //    if (rarity != null) { card.rarity = rarity.ToString(); }
                    //    if (text != null) { card.text = text.ToString(); }
                    //    if (toughness != null) { card.toughness = toughness.ToString(); }
                    //    if (type != null) { card.type = type.ToString(); }

                    //    // if you do an immediate insert the proggie runs well until ~20000 then slows to only an insert a second
                    //    //dbFactory.InsertCard(card);

                    //    if (lCards.Count(crds => crds.multiverseid == multiverseid.ToString()) == 0)
                    //    {
                    //        lCards.Add(card);
                    //    }
                    //}
                    //    //
                    //    // array objects
                    var t = prop.SelectToken("types");
                    var s = prop.SelectToken("subtypes");
                    var p = prop.SelectToken("printings");
                    var l = prop.SelectToken("legalities");
                    var fn = prop.SelectToken("foreignNames");
                    var c = prop.SelectToken("colors");
                    var ci = prop.SelectToken("colorIdentity");

                    //    // this will fill base lookup tables
                    if (t != null)
                    {
                        foreach (var typ in t)
                        { if (!lTypes.Contains(typ.ToString()))
                            {
                                lTypes.Add(typ.ToString());
                                cardtype = new Type();
                                cardtype.TypeName = typ.ToString();
                                dbFactory.InsertTypes(cardtype);
                            }
                        }
                    }
                    if (s != null)
                    {
                        // ToDo - SubType may actually have multiples
                        foreach (var subtyp in s)
                        { if (!lSubTypes.Contains(subtyp.ToString()))
                            {
                                lSubTypes.Add(subtyp.ToString());
                                cardSubType = new SubType();
                                cardSubType.SubTypeName = subtyp.ToString();
                                dbFactory.InsertSubTypes(cardSubType);
                            }
                        }
                    }
                    if (p != null)
                    {
                        foreach (var print in p)
                        { if (!lPrintings.Contains(print.ToString()))
                            {
                                lPrintings.Add(print.ToString());
                                cardPrinting = new Printing();
                                cardPrinting.PrintingName = print.ToString();
                                dbFactory.InsertPrintings(cardPrinting);
                            }
                        }
                    }
                    if (l != null)
                    {
                        foreach (var legal in l)
                        {
                            var mycardLegality = JsonConvert.DeserializeObject<Legality>(legal.ToString());
                            var find = lLegalities.FirstOrDefault(x => x.legality == mycardLegality.legality & x.format == mycardLegality.format );

                            if ((lLegalities.FirstOrDefault(x => x.legality == mycardLegality.legality & x.format == mycardLegality.format)) == null)
                            {
                                lLegalities.Add(mycardLegality);
                                dbFactory.InsertLegality(mycardLegality);
                            }
                        }
                    }
                    if (c != null)
                    {
                        foreach (var color in c)
                        { if (!lColors.Contains(color.ToString()))
                            {
                                lColors.Add(color.ToString());
                                cardColor = new Color();
                                cardColor.ColorName = color.ToString();
                                dbFactory.InsertColor(cardColor);
                            }
                        }
                    }
                    if (ci != null)
                    {
                        foreach (var colorident in ci)
                        { if (!lColorIdentities.Contains(colorident.ToString()))
                            {
                                lColorIdentities.Add(colorident.ToString());
                                cardColorIdentity = new ColorIdentity();
                                cardColorIdentity.ColorIdentityName = colorident.ToString();
                                dbFactory.InsertColorIdentity(cardColorIdentity);
                            }
                        }
                    }

                    // now insert the cards properties

                    // 
                    foreach (var cardProp in cardsProperties)
                    {
                        ProcessCards(cardProp, SetId);
                    }

                        //    if (fn != null)
                        //    {
                        //        Console.WriteLine(string.Format("todo: foreignNames {0}", fn.ToString(), ConsoleColor.Red));

                        //        //ForeignName forName = JsonConvert.DeserializeObject<ForeignName>(fn.ToString().Replace("\\", "").Replace("\r\n", "").Replace("[", "").Replace("]", ""));

                        //        // fn.ToString().Replace("\\","").Replace("\r\n","").Replace("[","").Replace("]","")

                        //        //foreach (var f in fn)
                        //        //{
                        //        //    //foreignn = new ForeignName();
                        //        //}

                        //    }

                    }

                Console.WriteLine("process next set + cards");
            }
            Console.WriteLine("attemping card db writes");
            foreach (Card c in lCards)
            {
                dbFactory.InsertCard(c);
            }
            //foreach (var obj in o)
            //{
            //    setCode = obj.Key;
            //    Console.WriteLine(string.Format("processing set {0}", setCode));
            //    JToken setInfo = obj.Value;
            //    ProcessSets(setInfo);
            //}

            //foreach (var objCards in o)
            //{
            //    JToken setInfo = objCards.Value;
            //    JToken jtCards = setInfo.SelectToken("cards");
            //    var cardsProperties = jtCards.Children();
            //    foreach (var prop in cardsProperties)
            //    {
            //        ProcessCardTokens(prop);
            //    }
            //}

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
            
            // booster is actually an arrary (where within there can be arrays at various locations - ToDo future work
            if (setInfo.SelectToken("booster") != null) { set.booster = setInfo.SelectToken("booster").ToString(); }

            //if (set.booster != null) { Console.WriteLine(string.Format("booster - {0}", set.booster)); }
            lSets.Add(set);
        }

        private void ProcessCards(JToken prop, int SetId)
        {
            Card card = new Card();
            var multiverseid = prop.SelectToken("multiverseid");
            var artist = prop.SelectToken("artist");
            var cmc = prop.SelectToken("cmc");
            var flavor = prop.SelectToken("flavor");
            var id = prop.SelectToken("id");
            var imageName = prop.SelectToken("imageName");
            var layout = prop.SelectToken("layout");
            var manaCost = prop.SelectToken("manaCost");
            var mciNumber = prop.SelectToken("mciNumber");
            var name = prop.SelectToken("name");
            var number = prop.SelectToken("number");
            var originalText = prop.SelectToken("originalText");
            var originalType = prop.SelectToken("originalType");
            var power = prop.SelectToken("power");
            var rarity = prop.SelectToken("rarity");
            var text = prop.SelectToken("text");
            var toughness = prop.SelectToken("toughness");
            var type = prop.SelectToken("type");

            if (multiverseid != null)
            {
                card.SetId = SetId;
                card.multiverseid = multiverseid.ToString();
                if (artist != null) { card.artist = artist.ToString(); }
                if (cmc != null) { card.cmc = cmc.ToString(); }
                if (flavor != null) { card.flavor = flavor.ToString(); }
                if (id != null) { card.id = id.ToString(); }
                if (imageName != null) { card.imageName = imageName.ToString(); }
                if (layout != null) { card.layout = layout.ToString(); }
                if (manaCost != null) { card.manaCost = manaCost.ToString(); }
                if (mciNumber != null) { card.mciNumber = mciNumber.ToString(); }
                if (name != null) { card.name = name.ToString(); }
                if (number != null) { card.number = number.ToString(); }
                if (originalText != null) { card.originalText = originalText.ToString(); }
                if (originalType != null) { card.originalType = originalType.ToString(); }
                if (power != null) { card.power = power.ToString(); }
                if (rarity != null) { card.rarity = rarity.ToString(); }
                if (text != null) { card.text = text.ToString(); }
                if (toughness != null) { card.toughness = toughness.ToString(); }
                if (type != null) { card.type = type.ToString(); }

                // if you do an immediate insert the proggie runs well until ~20000 then slows to only an insert a second
                //dbFactory.InsertCard(card);

                if (lCards.Count(crds => crds.multiverseid == multiverseid.ToString()) == 0)
                {
                    lCards.Add(card);
                    //dbFactory.InsertCard(card);
                }
            }
        }


        //private void ProcessCardTokens(JToken jtoken)
        //{
        //    var allPropsInList = jtoken.ToList();
        //    Card card = new Card();
        //    var multiverseid = jtoken.SelectToken("multiverseid");
        //    var artist = jtoken.SelectToken("artist");
        //    var cmc = jtoken.SelectToken("cmc");
        //    var flavor = jtoken.SelectToken("flavor");
        //    var id = jtoken.SelectToken("id");
        //    var imageName = jtoken.SelectToken("imageName");
        //    var layout = jtoken.SelectToken("layout");
        //    var manaCost = jtoken.SelectToken("manaCost");
        //    var mciNumber = jtoken.SelectToken("mciNumber");
        //    var name = jtoken.SelectToken("name");
        //    var number = jtoken.SelectToken("number");
        //    var originalText = jtoken.SelectToken("originalText");
        //    var originalType = jtoken.SelectToken("originalType");
        //    var power = jtoken.SelectToken("power");
        //    var rarity = jtoken.SelectToken("rarity");
        //    var text = jtoken.SelectToken("text");
        //    var toughness = jtoken.SelectToken("toughness");
        //    var type = jtoken.SelectToken("type");
        //    Console.WriteLine(string.Format("{0} - (1)", multiverseid, name));

        //    //if (lCards.Contains(crd => crd.multiverseid == multiverseid) != null)  { lCards.Add(card); }
        //    //IEnumerable<Card> cardss = lCards.Where(crd => crd.multiverseid == multiverseid.ToString());

        //    if (multiverseid != null)
        //    {
        //        card.multiverseid = multiverseid.ToString();
        //        if (artist != null) { card.artist = artist.ToString(); }
        //        if (cmc != null) { card.cmc = cmc.ToString(); }
        //        if (flavor != null) { card.flavor = flavor.ToString(); }
        //        if (id != null) { card.id = id.ToString(); }
        //        if (imageName != null) { card.imageName = imageName.ToString(); }
        //        if (layout != null) { card.layout = layout.ToString(); }
        //        if (manaCost != null) { card.manaCost = manaCost.ToString(); }
        //        if (mciNumber != null) { card.mciNumber = mciNumber.ToString(); }
        //        if (name != null) { card.name = name.ToString(); }
        //        if (number != null) { card.number = number.ToString(); }
        //        if (originalText != null) { card.originalText = originalText.ToString(); }
        //        if (originalType != null) { card.originalType = originalType.ToString(); }
        //        if (power != null) { card.power = power.ToString(); }
        //        if (rarity != null) { card.rarity = rarity.ToString(); }
        //        if (text != null) { card.text = text.ToString(); }
        //        if (toughness != null) { card.toughness = toughness.ToString(); }
        //        if (type != null) { card.type = type.ToString(); }


        //        if (lCards.Count(crds => crds.multiverseid == multiverseid.ToString()) == 0)
        //        {
        //            lCards.Add(card);
        //        }
        //    }
        //    //
        //    // array objects
        //    var t = jtoken.SelectToken("types");
        //    var s = jtoken.SelectToken("subtypes");
        //    var p = jtoken.SelectToken("printings");
        //    var l = jtoken.SelectToken("Legality");
        //    var fn = jtoken.SelectToken("foreignNames");
        //    var c = jtoken.SelectToken("colors");
        //    var ci = jtoken.SelectToken("colorIdentity");

        //    // this will fill base lookup tables
        //    if (t != null)
        //    {
        //        foreach (var typ in t)
        //        {  if (!lTypes.Contains(typ.ToString())) { lTypes.Add(typ.ToString()); }  }
        //    }
        //    if (s != null)
        //    {
        //        // ToDo - SubType may actually have multiples
        //        foreach (var subtyp in s)
        //        {  if (!lSubTypes.Contains(subtyp.ToString())) { lSubTypes.Add(subtyp.ToString()); }  }
        //    }
        //    if (p != null)
        //    {
        //        foreach (var print in p)
        //        {  if (!lPrintings.Contains(print.ToString())) { lPrintings.Add(print.ToString()); }   }
        //    }
        //    //if (l != null)
        //    //{
        //    //    foreach (var legal in l)
        //    //    { if (!lLegalities.Contains(legal.ToString())) { lLegalities.Add(legal.ToString()); } }
        //    //}
        //    if (c != null)
        //    {
        //        foreach (var color in c)
        //        { if (!lColors.Contains(color.ToString())) { lColors.Add(color.ToString()); } }
        //    }
        //    if (ci != null)
        //    {
        //        foreach (var colorident in ci)
        //        { if (!lColorIdentities.Contains(colorident.ToString())) { lColorIdentities.Add(colorident.ToString()); } }
        //    }
        //    if (fn != null)
        //    {
        //        Console.WriteLine(string.Format( "todo: foreignNames {0}",fn.ToString(), ConsoleColor.Red));

        //        //ForeignName forName = JsonConvert.DeserializeObject<ForeignName>(fn.ToString().Replace("\\", "").Replace("\r\n", "").Replace("[", "").Replace("]", ""));

        //        // fn.ToString().Replace("\\","").Replace("\r\n","").Replace("[","").Replace("]","")

        //        //foreach (var f in fn)
        //        //{
        //        //    //foreignn = new ForeignName();
        //        //}

        //    }
        //}


    }
}
