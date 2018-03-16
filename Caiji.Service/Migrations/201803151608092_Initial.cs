namespace Caiji.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Specialty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Specialty");
        }
    }
}
