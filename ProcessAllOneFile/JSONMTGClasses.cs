using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessAllOneFile.MTGJSON
{
    public class Set
    {
        public string name { get; set; }
        public string code { get; set; }
        public string magicCardsInfoCode { get; set; }
        public string releaseDate { get; set; }
        public string border { get; set; }
        public string type { get; set; }
        public List<string> booster { get; set; }
        public string mkm_name { get; set; }
        public int mkm_id { get; set; }

        //public List<Card> cards { get; set; }
        public virtual ICollection<Cards> cards { get; set; }
    }

    //
    public class Cards
    {
        // primary key
        //public int CardId { get; set; }

        public int SetId { get; set; }
        public virtual Set set { get; set; }

        public string artist { get; set; }
        public decimal cmc { get; set; }

        // 
        public List<string> colorIdentity { get; set; }

        // 
        public List<string> colors { get; set; }


        public string flavor { get; set; }
        public List<ForeignNames> foreignNames { get; set; }
        public string id { get; set; }
        public string imageName { get; set; }
        public string layout { get; set; }


        //public List<Legality> legalities { get; set; }
        public virtual ICollection<CardLegalities> cardLegalities { get; set; }

        public string manaCost { get; set; }
        public string mciNumber { get; set; }
        public int multiverseid { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string originalText { get; set; }
        public string originalType { get; set; }
        public string power { get; set; }
        public List<string> printings { get; set; }
        public string rarity { get; set; }
        public List<string> subtypes { get; set; }
        public string text { get; set; }
        public string toughness { get; set; }
        public string type { get; set; }
        public List<string> types { get; set; }
    }
    public class CardList : List<Cards>
    {
        //public Card[] CARDS { get; set; }
    }


    //
    public class Legalities
    {
        public int LegalityId { get; set; }
        public string format { get; set; }
        public string legality { get; set; }

        public virtual ICollection<CardLegalities> CardLegalities { get; set; }
    }
    public class CardLegalities
    {
        public int CardLegalityId { get; set; }
        public int CardId { get; set; }
        public int LegalityId { get; set; }

        public virtual Legalities Legality { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class Colors
    {
        public int ColorId { get; set; }
        public string Color { get; set; }

        public virtual ICollection<CardColors> CardColors { get; set; }
    }
    public class CardColors
    {
        public int CardColorsId { get; set; }

        public int CardId { get; set; }

        public int ColorId { get; set; }

        public virtual Colors Colors { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class ColorIdentities
    {
        public int ColorIdentityId { get; set; }
        public string ColorIdentity { get; set; }
        public virtual ICollection<CardColorIdentities> CardColorIdentities { get; set; }
    }
    public class CardColorIdentities
    {
        public int CardColorIdentityId { get; set; }
        public int ColorIdentityId { get; set; }
        public int CardId { get; set; }

        public virtual ColorIdentities ColorIdentities { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class ForeignNames
    {
        public int ForeignNamesId { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public int multiverseid { get; set; }

        public virtual ICollection<CardForeignNames> CardForeignNames { get; set; }
    }
    public class CardForeignNames
    {
        public int CardForeignNamesId { get; set; }
        public int ForeignNamesId { get; set; }
        public int CardId { get; set; }

        public virtual ForeignNames ForeignNames { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class Printings
    {
        public int PrintingsId { get; set; }
        public string Printing { get; set; }

        public virtual ICollection<CardPrintings> CardPrintings { get; set; }
    }
    public class CardPrintings
    {
        public int CardPrintingsId { get; set; }
        public int PrintingsId { get; set; }
        public int CardId { get; set; }

        public virtual Printings Printings { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class Types
    {
        public int TypesId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<CardTypes> CardTypes { get; set; }
    }
    public class CardTypes
    {
        public int CardTypesId { get; set; }
        public int TypesId { get; set; }
        public int CardId { get; set; }

        public virtual Types Types { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class SubTypes
    {
        public int SubTypesId { get; set; }
        public string SubType { get; set; }
        public virtual ICollection<CardSubTypes> CardSubTypes { get; set; }
    }
    public class CardSubTypes
    {
        public int CardSubTypesId { get; set; }
        public int SubTypesId { get; set; }
        public int CardId { get; set; }

        public virtual SubTypes SubTypes { get; set; }
        public virtual Cards Cards { get; set; }
    }


    public class Booster
    {
        public List<object> booster { get; set; }
    }
    public class RootObject
    {
        public Set MTGSET { get; set; }
    }

}
