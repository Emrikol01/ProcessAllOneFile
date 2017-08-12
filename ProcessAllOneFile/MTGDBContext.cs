using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MTGProcessAllOneFile
{
    public class MTGDBContext : System.Data.Entity.DbContext
    {
        public MTGDBContext() : base("name=MTGDBConStr")
        {

        }

        public DbSet<Set> Sets { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Legality> Legalities { get; set; }
        public DbSet<CardLegality> CardLegalities { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CardColor> CardColors { get; set; }
        public DbSet<ColorIdentity> ColorIdentities { get; set; }
        public DbSet<CardColorIdentity> CardColorIdentities { get; set; }
        public DbSet<ForeignName> ForeignNames { get; set; }
        //public DbSet<CardForeignName> CardForeignNames { get; set; }
        public DbSet<Printing> Printings { get; set; }
        public DbSet<CardPrinting> CardPrintings { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<SubType> SubTypes { get; set; }
        public DbSet<CardSubType> CardSubTypes { get; set; }

        public DbSet<Booster> Booster { get; set; }
    }
}
