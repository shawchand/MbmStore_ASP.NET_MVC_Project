namespace MbmStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCreatedDateAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CreatedDate", c => c.DateTime(nullable: true, defaultValueSql: "GETUTCDATE()", precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "CreatedDate");
        }
    }
}
