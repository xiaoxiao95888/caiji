namespace Caiji.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "Division", c => c.String());
            DropColumn("dbo.Hospitals", "Province");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hospitals", "Province", c => c.String());
            DropColumn("dbo.Hospitals", "Division");
        }
    }
}
