namespace CSRT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesOnModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Driver", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.VehicleMovement", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.VehicleMovement", "MilageOut", c => c.String(nullable: false));
            AddColumn("dbo.VehicleMovement", "Destination", c => c.String(nullable: false));
            AddColumn("dbo.VehicleMovement", "Mottor_Id", c => c.Int());
            AlterColumn("dbo.VehicleMovement", "NumberOfPeopleGoingOut", c => c.String(nullable: false));
            AlterColumn("dbo.VehicleMovement", "NameOfPeopleGoingOut", c => c.String(nullable: false));
            AlterColumn("dbo.VehicleMovement", "Purpose", c => c.String(nullable: false));
            CreateIndex("dbo.VehicleMovement", "Mottor_Id");
            AddForeignKey("dbo.VehicleMovement", "Mottor_Id", "dbo.Mottor", "Id");
            DropColumn("dbo.VehicleMovement", "TimeIn");
            DropColumn("dbo.VehicleMovement", "SignIn");
            DropColumn("dbo.VehicleMovement", "SignOut");
            DropColumn("dbo.VehicleMovement", "Remark");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleMovement", "Remark", c => c.String());
            AddColumn("dbo.VehicleMovement", "SignOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.VehicleMovement", "SignIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.VehicleMovement", "TimeIn", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.VehicleMovement", "Mottor_Id", "dbo.Mottor");
            DropIndex("dbo.VehicleMovement", new[] { "Mottor_Id" });
            AlterColumn("dbo.VehicleMovement", "Purpose", c => c.String());
            AlterColumn("dbo.VehicleMovement", "NameOfPeopleGoingOut", c => c.String());
            AlterColumn("dbo.VehicleMovement", "NumberOfPeopleGoingOut", c => c.String());
            DropColumn("dbo.VehicleMovement", "Mottor_Id");
            DropColumn("dbo.VehicleMovement", "Destination");
            DropColumn("dbo.VehicleMovement", "MilageOut");
            DropColumn("dbo.VehicleMovement", "Date");
            DropColumn("dbo.Driver", "PhoneNumber");
        }
    }
}
