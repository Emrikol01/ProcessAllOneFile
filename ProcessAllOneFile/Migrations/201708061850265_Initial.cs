namespace ProcessAllOneFile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boosters",
                c => new
                    {
                        BoosterId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BoosterId);
            
            CreateTable(
                "dbo.CardColorIdentities",
                c => new
                    {
                        CardColorIdentityId = c.Int(nullable: false, identity: true),
                        ColorIdentityId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardColorIdentityId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.ColorIdentities", t => t.ColorIdentityId, cascadeDelete: true)
                .Index(t => t.ColorIdentityId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        SetId = c.Int(nullable: false),
                        artist = c.String(),
                        cmc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        flavor = c.String(),
                        id = c.String(),
                        imageName = c.String(),
                        layout = c.String(),
                        manaCost = c.String(),
                        mciNumber = c.String(),
                        multiverseid = c.Int(nullable: false),
                        name = c.String(),
                        number = c.String(),
                        originalText = c.String(),
                        originalType = c.String(),
                        power = c.String(),
                        rarity = c.String(),
                        text = c.String(),
                        toughness = c.String(),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Sets", t => t.SetId, cascadeDelete: true)
                .Index(t => t.SetId);
            
            CreateTable(
                "dbo.CardColors",
                c => new
                    {
                        CardColorsId = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardColorsId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.CardLegalities",
                c => new
                    {
                        CardLegalityId = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        LegalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardLegalityId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Legalities", t => t.LegalityId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.LegalityId);
            
            CreateTable(
                "dbo.Legalities",
                c => new
                    {
                        LegalityId = c.Int(nullable: false, identity: true),
                        format = c.String(),
                        legality = c.String(),
                    })
                .PrimaryKey(t => t.LegalityId);
            
            CreateTable(
                "dbo.CardPrintings",
                c => new
                    {
                        CardPrintingsId = c.Int(nullable: false, identity: true),
                        PrintingsId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardPrintingsId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Printings", t => t.PrintingsId, cascadeDelete: true)
                .Index(t => t.PrintingsId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Printings",
                c => new
                    {
                        PrintingsId = c.Int(nullable: false, identity: true),
                        Printing = c.String(),
                    })
                .PrimaryKey(t => t.PrintingsId);
            
            CreateTable(
                "dbo.CardSubTypes",
                c => new
                    {
                        CardSubTypesId = c.Int(nullable: false, identity: true),
                        SubTypesId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardSubTypesId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.SubTypes", t => t.SubTypesId, cascadeDelete: true)
                .Index(t => t.SubTypesId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.SubTypes",
                c => new
                    {
                        SubTypesId = c.Int(nullable: false, identity: true),
                        SubType = c.String(),
                    })
                .PrimaryKey(t => t.SubTypesId);
            
            CreateTable(
                "dbo.CardTypes",
                c => new
                    {
                        CardTypesId = c.Int(nullable: false, identity: true),
                        TypesId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardTypesId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypesId, cascadeDelete: true)
                .Index(t => t.TypesId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypesId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TypesId);
            
            CreateTable(
                "dbo.ForeignNames",
                c => new
                    {
                        ForeignNamesId = c.Int(nullable: false, identity: true),
                        language = c.String(),
                        name = c.String(),
                        multiverseid = c.Int(nullable: false),
                        Cards_CardId = c.Int(),
                    })
                .PrimaryKey(t => t.ForeignNamesId)
                .ForeignKey("dbo.Cards", t => t.Cards_CardId)
                .Index(t => t.Cards_CardId);
            
            CreateTable(
                "dbo.CardForeignNames",
                c => new
                    {
                        CardForeignNamesId = c.Int(nullable: false, identity: true),
                        ForeignNamesId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardForeignNamesId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.ForeignNames", t => t.ForeignNamesId, cascadeDelete: true)
                .Index(t => t.ForeignNamesId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        SetId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        code = c.String(),
                        magicCardsInfoCode = c.String(),
                        releaseDate = c.String(),
                        border = c.String(),
                        type = c.String(),
                        mkm_name = c.String(),
                        mkm_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SetId);
            
            CreateTable(
                "dbo.ColorIdentities",
                c => new
                    {
                        ColorIdentityId = c.Int(nullable: false, identity: true),
                        ColorIdentity = c.String(),
                    })
                .PrimaryKey(t => t.ColorIdentityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardColorIdentities", "ColorIdentityId", "dbo.ColorIdentities");
            DropForeignKey("dbo.Cards", "SetId", "dbo.Sets");
            DropForeignKey("dbo.ForeignNames", "Cards_CardId", "dbo.Cards");
            DropForeignKey("dbo.CardForeignNames", "ForeignNamesId", "dbo.ForeignNames");
            DropForeignKey("dbo.CardForeignNames", "CardId", "dbo.Cards");
            DropForeignKey("dbo.CardTypes", "TypesId", "dbo.Types");
            DropForeignKey("dbo.CardTypes", "CardId", "dbo.Cards");
            DropForeignKey("dbo.CardSubTypes", "SubTypesId", "dbo.SubTypes");
            DropForeignKey("dbo.CardSubTypes", "CardId", "dbo.Cards");
            DropForeignKey("dbo.CardPrintings", "PrintingsId", "dbo.Printings");
            DropForeignKey("dbo.CardPrintings", "CardId", "dbo.Cards");
            DropForeignKey("dbo.CardLegalities", "LegalityId", "dbo.Legalities");
            DropForeignKey("dbo.CardLegalities", "CardId", "dbo.Cards");
            DropForeignKey("dbo.CardColors", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.CardColors", "CardId", "dbo.Cards");
            DropForeignKey("dbo.CardColorIdentities", "CardId", "dbo.Cards");
            DropIndex("dbo.CardForeignNames", new[] { "CardId" });
            DropIndex("dbo.CardForeignNames", new[] { "ForeignNamesId" });
            DropIndex("dbo.ForeignNames", new[] { "Cards_CardId" });
            DropIndex("dbo.CardTypes", new[] { "CardId" });
            DropIndex("dbo.CardTypes", new[] { "TypesId" });
            DropIndex("dbo.CardSubTypes", new[] { "CardId" });
            DropIndex("dbo.CardSubTypes", new[] { "SubTypesId" });
            DropIndex("dbo.CardPrintings", new[] { "CardId" });
            DropIndex("dbo.CardPrintings", new[] { "PrintingsId" });
            DropIndex("dbo.CardLegalities", new[] { "LegalityId" });
            DropIndex("dbo.CardLegalities", new[] { "CardId" });
            DropIndex("dbo.CardColors", new[] { "ColorId" });
            DropIndex("dbo.CardColors", new[] { "CardId" });
            DropIndex("dbo.Cards", new[] { "SetId" });
            DropIndex("dbo.CardColorIdentities", new[] { "CardId" });
            DropIndex("dbo.CardColorIdentities", new[] { "ColorIdentityId" });
            DropTable("dbo.ColorIdentities");
            DropTable("dbo.Sets");
            DropTable("dbo.CardForeignNames");
            DropTable("dbo.ForeignNames");
            DropTable("dbo.Types");
            DropTable("dbo.CardTypes");
            DropTable("dbo.SubTypes");
            DropTable("dbo.CardSubTypes");
            DropTable("dbo.Printings");
            DropTable("dbo.CardPrintings");
            DropTable("dbo.Legalities");
            DropTable("dbo.CardLegalities");
            DropTable("dbo.Colors");
            DropTable("dbo.CardColors");
            DropTable("dbo.Cards");
            DropTable("dbo.CardColorIdentities");
            DropTable("dbo.Boosters");
        }
    }
}
