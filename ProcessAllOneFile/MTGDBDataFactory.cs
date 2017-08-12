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
    }
}
