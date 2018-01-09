using System;
using Microsoft.EntityFrameworkCore;

namespace toofz.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILeaderboardsContext : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        DbSet<Leaderboard> Leaderboards { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Entry> Entries { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<DailyLeaderboard> DailyLeaderboards { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<DailyEntry> DailyEntries { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Player> Players { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Replay> Replays { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Product> Products { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Mode> Modes { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Run> Runs { get; }
        /// <summary>
        /// 
        /// </summary>
        DbSet<Character> Characters { get; }
    }
}