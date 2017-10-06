namespace toofz.NecroDancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GreenNickelLabrador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enemies", "DisplayName", c => c.String());
            AddColumn("dbo.Items", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "DisplayName");
            DropColumn("dbo.Enemies", "DisplayName");
        }
    }
}
