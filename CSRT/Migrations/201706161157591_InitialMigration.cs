namespace CSRT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MottoDriver",
                c => new
                    {
                        MotoId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.MotoId, t.DriverId })
                .ForeignKey("dbo.Driver", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Mottor", t => t.MotoId, cascadeDelete: true)
                .Index(t => t.MotoId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Mottor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MottorModelId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        PlateNumber = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.Id)
                .ForeignKey("dbo.MottorModel", t => t.Id)
                .ForeignKey("dbo.Vehicle", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MottorModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Milage",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MilageIn = c.String(),
                        MilageOut = c.String(),
                        MilageCovered = c.String(),
                        VehicleMovementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMovement", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.VehicleMovement",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MotoId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        NumberOfPeopleGoingOut = c.String(),
                        NameOfPeopleGoingOut = c.String(),
                        Purpose = c.String(),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        SignIn = c.Boolean(nullable: false),
                        SignOut = c.Boolean(nullable: false),
                        Remark = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.Id)
                .ForeignKey("dbo.Driver", t => t.Id)
                .ForeignKey("dbo.Mottor", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Milage", "Id", "dbo.VehicleMovement");
            DropForeignKey("dbo.VehicleMovement", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleMovement", "Id", "dbo.Mottor");
            DropForeignKey("dbo.VehicleMovement", "Id", "dbo.Driver");
            DropForeignKey("dbo.VehicleMovement", "Id", "dbo.Department");
            DropForeignKey("dbo.Mottor", "Id", "dbo.Vehicle");
            DropForeignKey("dbo.Mottor", "Id", "dbo.MottorModel");
            DropForeignKey("dbo.MottoDriver", "MotoId", "dbo.Mottor");
            DropForeignKey("dbo.Mottor", "Id", "dbo.Department");
            DropForeignKey("dbo.MottoDriver", "DriverId", "dbo.Driver");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.VehicleMovement", new[] { "User_Id" });
            DropIndex("dbo.VehicleMovement", new[] { "Id" });
            DropIndex("dbo.Milage", new[] { "Id" });
            DropIndex("dbo.Mottor", new[] { "Id" });
            DropIndex("dbo.MottoDriver", new[] { "DriverId" });
            DropIndex("dbo.MottoDriver", new[] { "MotoId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.VehicleMovement");
            DropTable("dbo.Milage");
            DropTable("dbo.Vehicle");
            DropTable("dbo.MottorModel");
            DropTable("dbo.Mottor");
            DropTable("dbo.MottoDriver");
            DropTable("dbo.Driver");
            DropTable("dbo.Department");
        }
    }
}
