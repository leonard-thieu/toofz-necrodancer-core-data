using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace toofz.Data.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InitialCreate : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

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

            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    ModeId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.ModeId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    SteamId = table.Column<long>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Exists = table.Column<bool>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.SteamId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Replays",
                columns: table => new
                {
                    ReplayId = table.Column<long>(nullable: false),
                    ErrorCode = table.Column<int>(nullable: true),
                    KilledBy = table.Column<string>(nullable: true),
                    Seed = table.Column<int>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replays", x => x.ReplayId);
                });

            migrationBuilder.CreateTable(
                name: "Runs",
                columns: table => new
                {
                    RunId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.RunId);
                });

            migrationBuilder.CreateTable(
                name: "DailyLeaderboards",
                columns: table => new
                {
                    LeaderboardId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    IsProduction = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLeaderboards", x => x.LeaderboardId);
                    table.ForeignKey(
                        name: "FK_DailyLeaderboards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaderboards",
                columns: table => new
                {
                    LeaderboardId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    IsCoOp = table.Column<bool>(nullable: false),
                    IsCustomMusic = table.Column<bool>(nullable: false),
                    IsProduction = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    ModeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    RunId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderboards", x => x.LeaderboardId);
                    table.ForeignKey(
                        name: "FK_Leaderboards_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leaderboards_Modes_ModeId",
                        column: x => x.ModeId,
                        principalTable: "Modes",
                        principalColumn: "ModeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leaderboards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leaderboards_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "RunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyEntries",
                columns: table => new
                {
                    LeaderboardId = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ReplayId = table.Column<long>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    SteamId = table.Column<long>(nullable: false),
                    Zone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyEntries", x => new { x.LeaderboardId, x.Rank });
                    table.ForeignKey(
                        name: "FK_DailyEntries_DailyLeaderboards_LeaderboardId",
                        column: x => x.LeaderboardId,
                        principalTable: "DailyLeaderboards",
                        principalColumn: "LeaderboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyEntries_Replays_ReplayId",
                        column: x => x.ReplayId,
                        principalTable: "Replays",
                        principalColumn: "ReplayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyEntries_Players_SteamId",
                        column: x => x.SteamId,
                        principalTable: "Players",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries_A",
                columns: table => new
                {
                    LeaderboardId = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ReplayId = table.Column<long>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    SteamId = table.Column<long>(nullable: false),
                    Zone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries_A", x => new { x.LeaderboardId, x.Rank });
                    table.ForeignKey(
                        name: "FK_Entries_A_Leaderboards_LeaderboardId",
                        column: x => x.LeaderboardId,
                        principalTable: "Leaderboards",
                        principalColumn: "LeaderboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_A_Replays_ReplayId",
                        column: x => x.ReplayId,
                        principalTable: "Replays",
                        principalColumn: "ReplayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_A_Players_SteamId",
                        column: x => x.SteamId,
                        principalTable: "Players",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries_B",
                columns: table => new
                {
                    LeaderboardId = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ReplayId = table.Column<long>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    SteamId = table.Column<long>(nullable: false),
                    Zone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries_B", x => new { x.LeaderboardId, x.Rank });
                    table.ForeignKey(
                        name: "FK_Entries_B_Leaderboards_LeaderboardId",
                        column: x => x.LeaderboardId,
                        principalTable: "Leaderboards",
                        principalColumn: "LeaderboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_B_Replays_ReplayId",
                        column: x => x.ReplayId,
                        principalTable: "Replays",
                        principalColumn: "ReplayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_B_Players_SteamId",
                        column: x => x.SteamId,
                        principalTable: "Players",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Name",
                table: "Characters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyEntries_ReplayId",
                table: "DailyEntries",
                column: "ReplayId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyEntries_SteamId",
                table: "DailyEntries",
                column: "SteamId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyLeaderboards_ProductId",
                table: "DailyLeaderboards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyLeaderboards",
                table: "DailyLeaderboards",
                columns: new[] { "Date", "ProductId", "IsProduction" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_A_ReplayId",
                table: "Entries_A",
                column: "ReplayId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_A_SteamId",
                table: "Entries_A",
                column: "SteamId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_B_ReplayId",
                table: "Entries_B",
                column: "ReplayId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_B_SteamId",
                table: "Entries_B",
                column: "SteamId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards_ModeId",
                table: "Leaderboards",
                column: "ModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards_ProductId",
                table: "Leaderboards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards_RunId",
                table: "Leaderboards",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards",
                table: "Leaderboards",
                columns: new[] { "CharacterId", "RunId", "ModeId", "ProductId", "IsProduction", "IsCoOp", "IsCustomMusic" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modes_Name",
                table: "Modes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Runs_Name",
                table: "Runs",
                column: "Name",
                unique: true);

            migrationBuilder.Sql(@"CREATE VIEW [dbo].[Entries]
AS

SELECT [SteamId], [LeaderboardId], [Score], [Rank], [Zone], [Level], [ReplayId]
FROM [Entries_A];");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[Entries];");

            migrationBuilder.DropTable(
                name: "DailyEntries");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Entries_B");

            migrationBuilder.DropTable(
                name: "Entries_A");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "DailyLeaderboards");

            migrationBuilder.DropTable(
                name: "Leaderboards");

            migrationBuilder.DropTable(
                name: "Replays");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Runs");
        }
    }
}
