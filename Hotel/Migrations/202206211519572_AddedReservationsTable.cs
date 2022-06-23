namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReservationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        DateOfRequest = c.DateTime(nullable: false),
                        LiveApartment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.LiveApartment_ID, cascadeDelete: true)
                .Index(t => t.LiveApartment_ID);   
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "LiveApartment_ID", "dbo.Apartments");
            DropIndex("dbo.Reservations", new[] { "LiveApartment_ID" });
            DropTable("dbo.Reservations");
        }
    }
}
