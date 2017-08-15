using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGProcessAllOneFile
{
    public class MTGDBDataFactory
    {
        MTGDBContext db = new MTGDBContext();

        // base tables
        public void InsertSet(Set set)
        {
            db.Sets.Add(set);
            db.SaveChanges();
        }
        public void InsertCard(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
        }
        public void InsertColor(Color color)
        {
            db.Colors.Add(color);
            db.SaveChanges();
        }
        public void InsertColorIdentity(ColorIdentity colorIdentity)
        {
            db.ColorIdentities.Add(colorIdentity);
            db.SaveChanges();
        }
        public void InsertTypes(Type type)
        {
            db.Types.Add(type);
            db.SaveChanges();
        }
        public void InsertSubTypes(SubType subType)
        {
            db.SubTypes.Add(subType);
            db.SaveChanges();
        }
        public void InsertPrintings(Printing printing)
        {
            db.Printings.Add(printing);
            db.SaveChanges();
        }
        public void InsertLegality(Legality legality)
        {
            db.Legalities.Add(legality);
            db.SaveChanges();
        }

        // join tables


        // other 
        public int GetSetIdByCode(string code)
        {
            Set set = db.Sets.FirstOrDefault(x => x.code == code);
            if (set != null) { return set.SetId; }
            else { return 0; }
        }
    }
}
