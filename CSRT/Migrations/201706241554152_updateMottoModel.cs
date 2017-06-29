namespace CSRT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMottoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MottorModel", "Total", c => c.String(nullable: false));
            AddColumn("dbo.MottorModel", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.MottorModel", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MottorModel", "Number", c => c.String(nullable: false));
            DropColumn("dbo.MottorModel", "Date");
            DropColumn("dbo.MottorModel", "Total");
        }
    }
}
