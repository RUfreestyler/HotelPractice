namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderDatesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        Apartment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.Apartment_ID, cascadeDelete: true)
                .Index(t => t.Apartment_ID);
            
            DropColumn("dbo.Apartments", "CheckInDate");
            DropColumn("dbo.Apartments", "CheckOutDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Apartments", "CheckOutDate", c => c.DateTime());
            AddColumn("dbo.Apartments", "CheckInDate", c => c.DateTime());
            DropForeignKey("dbo.OrderDates", "Apartment_ID", "dbo.Apartments");
            DropIndex("dbo.OrderDates", new[] { "Apartment_ID" });
            DropTable("dbo.OrderDates");
        }
    }
}
