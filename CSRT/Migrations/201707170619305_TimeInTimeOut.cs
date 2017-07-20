namespace CSRT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeInTimeOut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Milage", "TimeOut", c => c.DateTime());
            AddColumn("dbo.Milage", "TimeIn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Milage", "TimeIn");
            DropColumn("dbo.Milage", "TimeOut");
        }
    }
}
