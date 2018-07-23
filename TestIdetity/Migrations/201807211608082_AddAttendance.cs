namespace TestIdetity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            AddForeignKey("dbo.Attendances", "GigId", "dbo.Gigs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            AddForeignKey("dbo.Attendances", "GigId", "dbo.Gigs", "Id", cascadeDelete: true);
        }
    }
}
