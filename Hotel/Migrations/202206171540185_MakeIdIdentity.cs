namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeIdIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Guests", "LiveApartment_ID", "dbo.Apartments");
            DropPrimaryKey("dbo.Apartments");
            DropPrimaryKey("dbo.Guests");
            AlterColumn("dbo.Apartments", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Guests", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Apartments", "ID");
            AddPrimaryKey("dbo.Guests", "Id");
            AddForeignKey("dbo.Guests", "LiveApartment_ID", "dbo.Apartments", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guests", "LiveApartment_ID", "dbo.Apartments");
            DropPrimaryKey("dbo.Guests");
            DropPrimaryKey("dbo.Apartments");
            AlterColumn("dbo.Guests", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Apartments", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Guests", "Id");
            AddPrimaryKey("dbo.Apartments", "ID");
            AddForeignKey("dbo.Guests", "LiveApartment_ID", "dbo.Apartments", "ID", cascadeDelete: true);
        }
    }
}
