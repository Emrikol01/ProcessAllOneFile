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
        public DbSet<Cards> Cards { get; set; }
        public DbSet<Legalities> Legalities { get; set; }
        public DbSet<CardLegalities> CardLegalities { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<CardColors> CardColors { get; set; }
        public DbSet<ColorIdentities> ColorIdentities { get; set; }
        public DbSet<CardColorIdentities> CardColorIdentities { get; set; }
        public DbSet<ForeignNames> ForeignNames { get; set; }
        public DbSet<CardForeignNames> CardForeignNames { get; set; }
        public DbSet<Printings> Printings { get; set; }
        public DbSet<CardPrintings> CardPrintings { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<CardTypes> CardTypes { get; set; }
        public DbSet<SubTypes> SubTypes { get; set; }
        public DbSet<CardSubTypes> CardSubTypes { get; set; }

        public DbSet<Booster> Booster { get; set; }
    }
}
