using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace toofz.Data.NecroDancer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    FriendlyName = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: true),
                    OptionalStats_Boss = table.Column<bool>(nullable: false),
                    OptionalStats_BounceOnMovementFail = table.Column<bool>(nullable: false),
                    OptionalStats_Floating = table.Column<bool>(nullable: false),
                    OptionalStats_IgnoreLiquids = table.Column<bool>(nullable: false),
                    OptionalStats_IgnoreWalls = table.Column<bool>(nullable: false),
                    OptionalStats_IsMonkeyLike = table.Column<bool>(nullable: false),
                    OptionalStats_Massive = table.Column<bool>(nullable: false),
                    OptionalStats_Miniboss = table.Column<bool>(nullable: false),
                    Stats_BeatsPerMove = table.Column<int>(nullable: false),
                    Stats_CoinsToDrop = table.Column<int>(nullable: false),
                    Stats_DamagePerHit = table.Column<int>(nullable: false),
                    Stats_Health = table.Column<int>(nullable: false),
                    Stats_Movement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => new { x.Name, x.Type });
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Bouncer = table.Column<bool>(nullable: false),
                    CoinCost = table.Column<int>(nullable: true),
                    Consumable = table.Column<bool>(nullable: false),
                    Cooldown = table.Column<int>(nullable: true),
                    Data = table.Column<int>(nullable: true),
                    DiamondCost = table.Column<int>(nullable: true),
                    DiamondDealable = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(nullable: false),
                    FromTransmute = table.Column<bool>(nullable: true),
                    ImageHeight = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageWidth = table.Column<int>(nullable: false),
                    IsArmor = table.Column<bool>(nullable: false),
                    IsAxe = table.Column<bool>(nullable: false),
                    IsBlood = table.Column<bool>(nullable: false),
                    IsBlunderbuss = table.Column<bool>(nullable: false),
                    IsBow = table.Column<bool>(nullable: false),
                    IsBroadsword = table.Column<bool>(nullable: false),
                    IsCat = table.Column<bool>(nullable: false),
                    IsCoin = table.Column<bool>(nullable: false),
                    IsCrossbow = table.Column<bool>(nullable: false),
                    IsCutlass = table.Column<bool>(nullable: false),
                    IsDagger = table.Column<bool>(nullable: false),
                    IsDiamond = table.Column<bool>(nullable: false),
                    IsFamiliar = table.Column<bool>(nullable: false),
                    IsFlail = table.Column<bool>(nullable: false),
                    IsFood = table.Column<bool>(nullable: false),
                    IsFrost = table.Column<bool>(nullable: false),
                    IsGlass = table.Column<bool>(nullable: false),
                    IsGold = table.Column<bool>(nullable: false),
                    IsHarp = table.Column<bool>(nullable: false),
                    IsLongsword = table.Column<bool>(nullable: false),
                    IsMagicFood = table.Column<bool>(nullable: false),
                    IsObsidian = table.Column<bool>(nullable: false),
                    IsPhasing = table.Column<bool>(nullable: false),
                    IsPiercing = table.Column<bool>(nullable: false),
                    IsRapier = table.Column<bool>(nullable: false),
                    IsRifle = table.Column<bool>(nullable: false),
                    IsScroll = table.Column<bool>(nullable: false),
                    IsShovel = table.Column<bool>(nullable: false),
                    IsSpear = table.Column<bool>(nullable: false),
                    IsSpell = table.Column<bool>(nullable: false),
                    IsStackable = table.Column<bool>(nullable: false),
                    IsStaff = table.Column<bool>(nullable: false),
                    IsTemp = table.Column<bool>(nullable: false),
                    IsTitanium = table.Column<bool>(nullable: false),
                    IsTorch = table.Column<bool>(nullable: false),
                    IsWarhammer = table.Column<bool>(nullable: false),
                    IsWeapon = table.Column<bool>(nullable: false),
                    IsWhip = table.Column<bool>(nullable: false),
                    PlayerKnockback = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Set = table.Column<string>(nullable: true),
                    Slot = table.Column<string>(nullable: true),
                    TemporaryMapSight = table.Column<bool>(nullable: false),
                    UseGreater = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
