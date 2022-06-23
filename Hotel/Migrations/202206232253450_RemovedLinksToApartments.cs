namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedLinksToApartments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Guests", "LiveApartment_ID", "dbo.Apartments");
            DropForeignKey("dbo.OrderDates", "Apartment_ID", "dbo.Apartments");
            DropForeignKey("dbo.Reservations", "LiveApartment_ID", "dbo.Apartments");
            DropIndex("dbo.Guests", new[] { "LiveApartment_ID" });
            DropIndex("dbo.OrderDates", new[] { "Apartment_ID" });
            DropIndex("dbo.Reservations", new[] { "LiveApartment_ID" });
            AddColumn("dbo.Guests", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDates", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "Number", c => c.Int(nullable: false));
            DropColumn("dbo.Guests", "LiveApartment_ID");
            DropColumn("dbo.OrderDates", "Apartment_ID");
            DropColumn("dbo.Reservations", "LiveApartment_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "LiveApartment_ID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDates", "Apartment_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Guests", "LiveApartment_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Number");
            DropColumn("dbo.OrderDates", "Number");
            DropColumn("dbo.Guests", "Number");
            CreateIndex("dbo.Reservations", "LiveApartment_ID");
            CreateIndex("dbo.OrderDates", "Apartment_ID");
            CreateIndex("dbo.Guests", "LiveApartment_ID");
            AddForeignKey("dbo.Reservations", "LiveApartment_ID", "dbo.Apartments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDates", "Apartment_ID", "dbo.Apartments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Guests", "LiveApartment_ID", "dbo.Apartments", "ID", cascadeDelete: true);
        }
    }
}
