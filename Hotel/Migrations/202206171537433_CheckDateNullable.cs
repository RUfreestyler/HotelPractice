namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apartments", "CheckInDate", c => c.DateTime());
            AlterColumn("dbo.Apartments", "CheckOutDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apartments", "CheckOutDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Apartments", "CheckInDate", c => c.DateTime(nullable: false));
        }
    }
}
