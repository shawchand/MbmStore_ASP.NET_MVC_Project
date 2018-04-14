namespace MbmStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Birthdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Address = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Invoice_InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Invoice", t => t.Invoice_InvoiceId)
                .Index(t => t.ProductId)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        CustomerID = c.Int(nullable: false),
                        PhoneType = c.String(),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Author = c.String(),
                        Publisher = c.String(),
                        Published = c.Short(nullable: false),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Director = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.MusicCD",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Artist = c.String(),
                        Label = c.String(),
                        Released = c.Short(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        MusicCD_ProductId = c.Int(),
                        Title1 = c.String(),
                        Composer = c.String(),
                        Length = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.MusicCD", t => t.MusicCD_ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.MusicCD_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MusicCD", "MusicCD_ProductId", "dbo.MusicCD");
            DropForeignKey("dbo.MusicCD", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Movie", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Book", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Phone", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.OrderItem", "Invoice_InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropIndex("dbo.MusicCD", new[] { "MusicCD_ProductId" });
            DropIndex("dbo.MusicCD", new[] { "ProductId" });
            DropIndex("dbo.Movie", new[] { "ProductId" });
            DropIndex("dbo.Book", new[] { "ProductId" });
            DropIndex("dbo.Phone", new[] { "CustomerID" });
            DropIndex("dbo.OrderItem", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropTable("dbo.MusicCD");
            DropTable("dbo.Movie");
            DropTable("dbo.Book");
            DropTable("dbo.Phone");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
            DropTable("dbo.Product");
        }
    }
}
