namespace CSRT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMottorModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleMovement", "Mottor_Id", "dbo.Mottor");
            DropIndex("dbo.VehicleMovement", new[] { "Mottor_Id" });
            DropColumn("dbo.VehicleMovement", "Mottor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleMovement", "Mottor_Id", c => c.Int());
            CreateIndex("dbo.VehicleMovement", "Mottor_Id");
            AddForeignKey("dbo.VehicleMovement", "Mottor_Id", "dbo.Mottor", "Id");
        }
    }
}
