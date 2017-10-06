namespace toofz.NecroDancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class OliveAluminiumGermanShepherd : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE [dbo].[Enemies]
SET [DisplayName] = ''
WHERE [DisplayName] IS NULL;");
            Sql(@"UPDATE [dbo].[Items]
SET [DisplayName] = ''
WHERE [DisplayName] IS NULL;");
            AlterColumn("dbo.Enemies", "DisplayName", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "DisplayName", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Items", "DisplayName", c => c.String());
            AlterColumn("dbo.Enemies", "DisplayName", c => c.String());
        }
    }
}
