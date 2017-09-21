namespace toofz.NecroDancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FuschiaSteelSheepdog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enemies", "SpriteSheet_FlipXOff", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_AutoFlip", c => c.Boolean(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_FlipX", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Enemies", "SpriteSheet_FlipX");
            DropColumn("dbo.Enemies", "SpriteSheet_AutoFlip");
            DropColumn("dbo.Enemies", "SpriteSheet_FlipXOff");
        }
    }
}
