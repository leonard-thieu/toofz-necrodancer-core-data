namespace toofz.NecroDancer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enemies",
                c => new
                {
                    Name = c.String(nullable: false, maxLength: 128),
                    Type = c.Int(nullable: false),
                    Id = c.Int(),
                    FriendlyName = c.String(),
                    Stats_BeatsPerMove = c.Int(nullable: false),
                    Stats_CoinsToDrop = c.Int(nullable: false),
                    Stats_DamagePerHit = c.Int(nullable: false),
                    Stats_Health = c.Int(nullable: false),
                    Stats_Movement = c.String(),
                    OptionalStats_Boss = c.Boolean(nullable: false),
                    OptionalStats_BounceOnMovementFail = c.Boolean(nullable: false),
                    OptionalStats_Floating = c.Boolean(nullable: false),
                    OptionalStats_IgnoreLiquids = c.Boolean(nullable: false),
                    OptionalStats_IgnoreWalls = c.Boolean(nullable: false),
                    OptionalStats_IsMonkeyLike = c.Boolean(nullable: false),
                    OptionalStats_Massive = c.Boolean(nullable: false),
                    OptionalStats_Miniboss = c.Boolean(nullable: false),
                    DisplayName = c.String(nullable: false),
                })
                .PrimaryKey(t => new { t.Name, t.Type });

            CreateTable(
                "dbo.Items",
                c => new
                {
                    Name = c.String(nullable: false, maxLength: 128),
                    ImagePath = c.String(),
                    Bouncer = c.Boolean(nullable: false),
                    CoinCost = c.Int(),
                    Consumable = c.Boolean(nullable: false),
                    Cooldown = c.Int(),
                    Data = c.Int(),
                    DiamondCost = c.Int(),
                    DiamondDealable = c.Int(),
                    FromTransmute = c.Boolean(),
                    ImageHeight = c.Int(nullable: false),
                    ImageWidth = c.Int(nullable: false),
                    IsArmor = c.Boolean(nullable: false),
                    IsAxe = c.Boolean(nullable: false),
                    IsBlood = c.Boolean(nullable: false),
                    IsBlunderbuss = c.Boolean(nullable: false),
                    IsBow = c.Boolean(nullable: false),
                    IsBroadsword = c.Boolean(nullable: false),
                    IsCat = c.Boolean(nullable: false),
                    IsCoin = c.Boolean(nullable: false),
                    IsCrossbow = c.Boolean(nullable: false),
                    IsCutlass = c.Boolean(nullable: false),
                    IsDagger = c.Boolean(nullable: false),
                    IsDiamond = c.Boolean(nullable: false),
                    IsFamiliar = c.Boolean(nullable: false),
                    IsFlail = c.Boolean(nullable: false),
                    IsFood = c.Boolean(nullable: false),
                    IsFrost = c.Boolean(nullable: false),
                    IsGlass = c.Boolean(nullable: false),
                    IsGold = c.Boolean(nullable: false),
                    IsHarp = c.Boolean(nullable: false),
                    IsLongsword = c.Boolean(nullable: false),
                    IsMagicFood = c.Boolean(nullable: false),
                    IsObsidian = c.Boolean(nullable: false),
                    IsPhasing = c.Boolean(nullable: false),
                    IsPiercing = c.Boolean(nullable: false),
                    IsRapier = c.Boolean(nullable: false),
                    IsRifle = c.Boolean(nullable: false),
                    IsScroll = c.Boolean(nullable: false),
                    IsShovel = c.Boolean(nullable: false),
                    IsSpear = c.Boolean(nullable: false),
                    IsSpell = c.Boolean(nullable: false),
                    IsStackable = c.Boolean(nullable: false),
                    IsStaff = c.Boolean(nullable: false),
                    IsTemp = c.Boolean(nullable: false),
                    IsTitanium = c.Boolean(nullable: false),
                    IsTorch = c.Boolean(nullable: false),
                    IsWarhammer = c.Boolean(nullable: false),
                    IsWeapon = c.Boolean(nullable: false),
                    IsWhip = c.Boolean(nullable: false),
                    PlayerKnockback = c.Boolean(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Set = c.String(),
                    Slot = c.String(),
                    TemporaryMapSight = c.Boolean(nullable: false),
                    UseGreater = c.Boolean(),
                    DisplayName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Name);
        }

        public override void Down()
        {
            DropTable("dbo.Items");
            DropTable("dbo.Enemies");
        }
    }
}
