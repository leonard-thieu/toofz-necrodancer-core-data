namespace toofz.NecroDancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class LimePlatinumSchnauzer : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enemies", new[] { "Name" });
            DropIndex("dbo.Items", new[] { "Name" });
            AddColumn("dbo.Items", "QuantityOffsetY", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Cooldown", c => c.Int());
            AlterColumn("dbo.Items", "Data", c => c.Int());
            AlterColumn("dbo.Items", "DiamondDealable", c => c.Int());
            AlterColumn("dbo.Items", "FromTransmute", c => c.Boolean());
            AlterColumn("dbo.Items", "UseGreater", c => c.Boolean());
            DropColumn("dbo.Enemies", "LevelEditor");
            DropColumn("dbo.Enemies", "Name");
            DropColumn("dbo.Enemies", "Bouncer_Min");
            DropColumn("dbo.Enemies", "Bouncer_Max");
            DropColumn("dbo.Enemies", "Bouncer_Power");
            DropColumn("dbo.Enemies", "Bouncer_Steps");
            DropColumn("dbo.Enemies", "Particle_HitPath");
            DropColumn("dbo.Enemies", "Shadow_Path");
            DropColumn("dbo.Enemies", "Shadow_OffsetX");
            DropColumn("dbo.Enemies", "Shadow_OffsetY");
            DropColumn("dbo.Enemies", "SpriteSheet_Path");
            DropColumn("dbo.Enemies", "SpriteSheet_FrameCount");
            DropColumn("dbo.Enemies", "SpriteSheet_FrameWidth");
            DropColumn("dbo.Enemies", "SpriteSheet_FrameHeight");
            DropColumn("dbo.Enemies", "SpriteSheet_OffsetX");
            DropColumn("dbo.Enemies", "SpriteSheet_OffsetY");
            DropColumn("dbo.Enemies", "SpriteSheet_OffsetZ");
            DropColumn("dbo.Enemies", "SpriteSheet_HeartOffsetX");
            DropColumn("dbo.Enemies", "SpriteSheet_HeartOffsetY");
            DropColumn("dbo.Enemies", "SpriteSheet_FlipXOff");
            DropColumn("dbo.Enemies", "SpriteSheet_AutoFlip");
            DropColumn("dbo.Enemies", "SpriteSheet_FlipX");
            DropColumn("dbo.Enemies", "Stats_Priority");
            DropColumn("dbo.Enemies", "Tweens_Move");
            DropColumn("dbo.Enemies", "Tweens_MoveShadow");
            DropColumn("dbo.Enemies", "Tweens_Hit");
            DropColumn("dbo.Enemies", "Tweens_HitShadow");
            DropColumn("dbo.Items", "ChestChance");
            DropColumn("dbo.Items", "Flyaway_Id");
            DropColumn("dbo.Items", "Flyaway_Text");
            DropColumn("dbo.Items", "FrameCount");
            DropColumn("dbo.Items", "HideQuantity");
            DropColumn("dbo.Items", "Hint_Id");
            DropColumn("dbo.Items", "Hint_Text");
            DropColumn("dbo.Items", "LevelEditor");
            DropColumn("dbo.Items", "LockedChestChance");
            DropColumn("dbo.Items", "LockedShopChance");
            DropColumn("dbo.Items", "Name");
            DropColumn("dbo.Items", "OffsetY");
            DropColumn("dbo.Items", "QuantityYOff");
            DropColumn("dbo.Items", "ScreenFlash");
            DropColumn("dbo.Items", "ScreenShake");
            DropColumn("dbo.Items", "ShopChance");
            DropColumn("dbo.Items", "SlotPriority");
            DropColumn("dbo.Items", "Sound");
            DropColumn("dbo.Items", "Spell");
            DropColumn("dbo.Items", "Unlocked");
            DropColumn("dbo.Items", "UrnChance");
            RenameColumn("dbo.Enemies", "ElementName", "Name");
            RenameColumn("dbo.Items", "ElementName", "Name");
        }

        public override void Down()
        {
            RenameColumn("dbo.Items", "Name", "ElementName");
            RenameColumn("dbo.Enemies", "Name", "ElementName");
            AddColumn("dbo.Items", "UrnChance", c => c.String());
            AddColumn("dbo.Items", "Unlocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "Spell", c => c.String());
            AddColumn("dbo.Items", "Sound", c => c.String());
            AddColumn("dbo.Items", "SlotPriority", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "ShopChance", c => c.String());
            AddColumn("dbo.Items", "ScreenShake", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "ScreenFlash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "QuantityYOff", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "OffsetY", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Name", c => c.String(maxLength: 450));
            AddColumn("dbo.Items", "LockedShopChance", c => c.String());
            AddColumn("dbo.Items", "LockedChestChance", c => c.String());
            AddColumn("dbo.Items", "LevelEditor", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "Hint_Text", c => c.String());
            AddColumn("dbo.Items", "Hint_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "HideQuantity", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "FrameCount", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Flyaway_Text", c => c.String());
            AddColumn("dbo.Items", "Flyaway_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "ChestChance", c => c.String());
            AddColumn("dbo.Enemies", "Tweens_HitShadow", c => c.String());
            AddColumn("dbo.Enemies", "Tweens_Hit", c => c.String());
            AddColumn("dbo.Enemies", "Tweens_MoveShadow", c => c.String());
            AddColumn("dbo.Enemies", "Tweens_Move", c => c.String());
            AddColumn("dbo.Enemies", "Stats_Priority", c => c.Int());
            AddColumn("dbo.Enemies", "SpriteSheet_FlipX", c => c.Boolean(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_AutoFlip", c => c.Boolean(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_FlipXOff", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_HeartOffsetY", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_HeartOffsetX", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_OffsetZ", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_OffsetY", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_OffsetX", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_FrameHeight", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_FrameWidth", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_FrameCount", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "SpriteSheet_Path", c => c.String());
            AddColumn("dbo.Enemies", "Shadow_OffsetY", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "Shadow_OffsetX", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "Shadow_Path", c => c.String());
            AddColumn("dbo.Enemies", "Particle_HitPath", c => c.String());
            AddColumn("dbo.Enemies", "Bouncer_Steps", c => c.Int(nullable: false));
            AddColumn("dbo.Enemies", "Bouncer_Power", c => c.Double(nullable: false));
            AddColumn("dbo.Enemies", "Bouncer_Max", c => c.Double(nullable: false));
            AddColumn("dbo.Enemies", "Bouncer_Min", c => c.Double(nullable: false));
            AddColumn("dbo.Enemies", "Name", c => c.String(maxLength: 450));
            AddColumn("dbo.Enemies", "LevelEditor", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Items", "UseGreater", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Items", "FromTransmute", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Items", "DiamondDealable", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Data", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Cooldown", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "QuantityOffsetY");
            CreateIndex("dbo.Items", "Name");
            CreateIndex("dbo.Enemies", "Name");
        }
    }
}
