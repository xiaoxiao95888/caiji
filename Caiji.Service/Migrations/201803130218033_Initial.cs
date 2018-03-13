namespace Caiji.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Title = c.String(),
                        Post = c.String(),
                        DepartmentId = c.Guid(nullable: false),
                        Describe = c.String(),
                        Url = c.String(),
                        Flags = c.String(),
                        UpdateTime = c.DateTime(),
                        CreatedTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        HospitalId = c.Guid(nullable: false),
                        Url = c.String(),
                        UpdateTime = c.DateTime(),
                        CreatedTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Level = c.String(),
                        TelNumber = c.String(),
                        Lng = c.String(),
                        Lat = c.String(),
                        Site = c.String(),
                        Url = c.String(),
                        UpdateTime = c.DateTime(),
                        CreatedTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Clients", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "HospitalId" });
            DropIndex("dbo.Clients", new[] { "DepartmentId" });
            DropTable("dbo.Hospitals");
            DropTable("dbo.Departments");
            DropTable("dbo.Clients");
        }
    }
}
