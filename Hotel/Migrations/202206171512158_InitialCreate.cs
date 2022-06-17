namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        Capacity = c.Int(nullable: false),
                        PricePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        LiveApartment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.LiveApartment_ID, cascadeDelete: true)
                .Index(t => t.LiveApartment_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guests", "LiveApartment_ID", "dbo.Apartments");
            DropIndex("dbo.Guests", new[] { "LiveApartment_ID" });
            DropTable("dbo.Guests");
            DropTable("dbo.Apartments");
        }
    }
}
