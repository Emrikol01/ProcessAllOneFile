using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGProcessAllOneFile
{

    // https://msdn.microsoft.com/en-us/library/jj713564(v=vs.113).aspx


    //
    public class Set
    {
        [Key]
        [Required]
        public int SetId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string magicCardsInfoCode { get; set; }
        public string releaseDate { get; set; }
        public string border { get; set; }
        public string type { get; set; }
        //public List<string> booster { get; set; }
        public string mkm_name { get; set; }
        public string mkm_id { get; set; }
        public string oldCode { get; set; }
        public string magicRaritiesCodes { get; set; }
        public string onlineOnly { get; set; }
        public string translations { get; set; }
        public string booster { get; set; }
        //public List<Card> cards { get; set; }
        public virtual ICollection<Cards> cards { get; set; }


        //JToken jtCode = setInfo.SelectToken("code");
        //JToken jtoldCode = setInfo.SelectToken("oldCode");
        //JToken jtmagicCardsInfoCode = setInfo.SelectToken("magicCardsInfoCode");
        //JToken jtborder = setInfo.SelectToken("border");
        //JToken jttype = setInfo.SelectToken("type");
        //JToken jtmkm_name = setInfo.SelectToken("mkm_name");
        //JToken jtmkm_id = setInfo.SelectToken("mkm_id");
        //JToken jtmagicRaritiesCodes = setInfo.SelectToken("magicRaritiesCodes");
        //JToken jtonlineOnly = setInfo.SelectToken("onlineOnly");
        //JToken jttranslations = setInfo.SelectToken("translations");
        //JToken jtbooster = setInfo.SelectToken("booster");
    }

    //
    public class Cards
    {
        // primary key
        [Key]
        [Required]
        public int CardId { get; set; }
        [Required]
        public int SetId { get; set; }
        public virtual Set set { get; set; }
        public string artist { get; set; }
        public decimal cmc { get; set; }
        public string flavor { get; set; }
        public string id { get; set; }
        public string imageName { get; set; }
        public string layout { get; set; }
        public string manaCost { get; set; }
        public string mciNumber { get; set; }
        [Required]
        public int multiverseid { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string originalText { get; set; }
        public string originalType { get; set; }
        public string power { get; set; }
        public string rarity { get; set; }
        public string text { get; set; }
        public string toughness { get; set; }
        public string type { get; set; }

        // foreign key references
        //public List<string> colorIdentity { get; set; }
        public virtual ICollection<CardColorIdentities> cardColorIdentities { get; set; }
        //public List<string> colors { get; set; }
        public virtual ICollection<CardColors> cardColors { get; set; }
        //public List<Legality> legalities { get; set; }
        public virtual ICollection<CardLegalities> cardLegalities { get; set; }
        //
        //public List<string> types { get; set; }
        public virtual ICollection<CardTypes> cardTypes{ get; set; }
        //public List<string> subtypes { get; set; }
        public virtual ICollection<CardSubTypes> cardSubTypes { get; set; }
        //public List<string> printings { get; set; }
        public virtual ICollection<CardPrintings> cardPrintings { get; set; }
        //public List<ForeignNames> foreignNames { get; set; }
        public virtual ICollection<ForeignNames> foreignNames { get; set; }
    }
    public class CardList : List<Cards>
    {
        //public Card[] CARDS { get; set; }
    }


    //
    public class Legalities
    {
        [Key]
        [Required]
        public int LegalityId { get; set; }
        public string format { get; set; }
        public string legality { get; set; }

        public virtual ICollection<CardLegalities> CardLegalities { get; set; }
    }
    public class CardLegalities
    {
        [Key]
        [Required]
        public int CardLegalityId { get; set; }
        public int CardId { get; set; }
        public int LegalityId { get; set; }

        public virtual Legalities Legality { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class Colors
    {
        [Key]
        [Required]
        public int ColorId { get; set; }
        public string Color { get; set; }

        public virtual ICollection<CardColors> CardColors { get; set; }
    }
    public class CardColors
    {
        [Key]
        [Required]
        public int CardColorsId { get; set; }

        public int CardId { get; set; }

        public int ColorId { get; set; }

        public virtual Colors Colors { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class ColorIdentities
    {
        [Key]
        [Required]
        public int ColorIdentityId { get; set; }
        public string ColorIdentity { get; set; }
        public virtual ICollection<CardColorIdentities> CardColorIdentities { get; set; }
    }
    public class CardColorIdentities
    {
        [Key]
        [Required]
        public int CardColorIdentityId { get; set; }
        public int ColorIdentityId { get; set; }
        public int CardId { get; set; }

        public virtual ColorIdentities ColorIdentities { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class ForeignNames
    {
        [Key]
        [Required]
        public int ForeignNamesId { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public int multiverseid { get; set; }

        public virtual ICollection<CardForeignNames> CardForeignNames { get; set; }
    }
    public class CardForeignNames
    {
        [Key]
        [Required]
        public int CardForeignNamesId { get; set; }
        public int ForeignNamesId { get; set; }
        public int CardId { get; set; }

        public virtual ForeignNames ForeignNames { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class Printings
    {
        [Key]
        [Required]
        public int PrintingsId { get; set; }
        public string Printing { get; set; }

        public virtual ICollection<CardPrintings> CardPrintings { get; set; }
    }
    public class CardPrintings
    {
        [Key]
        [Required]
        public int CardPrintingsId { get; set; }
        public int PrintingsId { get; set; }
        public int CardId { get; set; }

        public virtual Printings Printings { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class Types
    {
        [Key]
        [Required]
        public int TypesId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<CardTypes> CardTypes { get; set; }
    }
    public class CardTypes
    {
        [Key]
        [Required]
        public int CardTypesId { get; set; }
        public int TypesId { get; set; }
        public int CardId { get; set; }

        public virtual Types Types { get; set; }
        public virtual Cards Cards { get; set; }
    }


    //
    public class SubTypes
    {
        [Key]
        [Required]
        public int SubTypesId { get; set; }
        public string SubType { get; set; }
        public virtual ICollection<CardSubTypes> CardSubTypes { get; set; }
    }
    public class CardSubTypes
    {
        [Key]
        [Required]
        public int CardSubTypesId { get; set; }
        public int SubTypesId { get; set; }
        public int CardId { get; set; }

        public virtual SubTypes SubTypes { get; set; }
        public virtual Cards Cards { get; set; }
    }


    public class Booster
    {
        [Key]
        [Required]
        public int BoosterId { get; set; }
        public List<object> booster { get; set; }
    }
    public class RootObject
    {
        public Set MTGSET { get; set; }
    }

}
