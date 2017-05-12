namespace CSRT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarDrivers",
                c => new
                    {
                        CarId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Car_MilageId = c.Int(),
                    })
                .PrimaryKey(t => new { t.CarId, t.DriverId })
                .ForeignKey("dbo.Cars", t => t.Car_MilageId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.Car_MilageId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        MilageId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        VehicleNumber = c.String(),
                        CarStatus = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MilageId)
                .ForeignKey("dbo.Milages", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Milages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MilageIn = c.String(),
                        MilageOut = c.String(),
                        MilageCovered = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.VehicleMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        NumberOfPeopleGoingOut = c.String(),
                        NameOfPeopleGoingOut = c.String(),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        SignIn = c.Boolean(nullable: false),
                        SignOut = c.Boolean(nullable: false),
                        Remark = c.String(),
                        Car_MilageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_MilageId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.DepartmentId)
                .Index(t => t.Car_MilageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleMovements", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.VehicleMovements", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.VehicleMovements", "Car_MilageId", "dbo.Cars");
            DropForeignKey("dbo.Departments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cars", "Id", "dbo.Departments");
            DropForeignKey("dbo.CarDrivers", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Cars", "Id", "dbo.Milages");
            DropForeignKey("dbo.CarDrivers", "Car_MilageId", "dbo.Cars");
            DropIndex("dbo.VehicleMovements", new[] { "Car_MilageId" });
            DropIndex("dbo.VehicleMovements", new[] { "DepartmentId" });
            DropIndex("dbo.VehicleMovements", new[] { "DriverId" });
            DropIndex("dbo.Departments", new[] { "User_Id" });
            DropIndex("dbo.Cars", new[] { "Id" });
            DropIndex("dbo.CarDrivers", new[] { "Car_MilageId" });
            DropIndex("dbo.CarDrivers", new[] { "DriverId" });
            DropTable("dbo.VehicleMovements");
            DropTable("dbo.Departments");
            DropTable("dbo.Drivers");
            DropTable("dbo.Milages");
            DropTable("dbo.Cars");
            DropTable("dbo.CarDrivers");
        }
    }
}
