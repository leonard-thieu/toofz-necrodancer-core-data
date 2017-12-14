using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using toofz.Data.Properties;

namespace toofz.Data
{
    /// <summary>
    /// Contains extension methods for <see cref="LeaderboardsContext"/>.
    /// </summary>
    public static class LeaderboardsContextExtensions
    {
        public static void EnsureSeedData(this LeaderboardsContext context)
        {
            if (!context.Database.GetPendingMigrations().Any())
            {
                if (!context.Products.Any())
                {
                    var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(Resources.Products);
                    context.Products.AddRange(products);

                    context.SaveChanges();
                }

                if (!context.Modes.Any())
                {
                    var modes = JsonConvert.DeserializeObject<IEnumerable<Mode>>(Resources.Modes);
                    context.Modes.AddRange(modes);

                    context.SaveChanges();
                }

                if (!context.Runs.Any())
                {
                    var runs = JsonConvert.DeserializeObject<IEnumerable<Run>>(Resources.Runs);
                    context.Runs.AddRange(runs);

                    context.SaveChanges();
                }

                if (!context.Characters.Any())
                {
                    var characters = JsonConvert.DeserializeObject<IEnumerable<Character>>(Resources.Characters);
                    context.Characters.AddRange(characters);

                    context.SaveChanges();
                }

                if (!context.Leaderboards.Any())
                {
                    var leaderboards = JsonConvert.DeserializeObject<IEnumerable<Leaderboard>>(Resources.Leaderboards);
                    context.Leaderboards.AddRange(leaderboards);

                    context.SaveChanges();
                }

                if (!context.DailyLeaderboards.Any())
                {
                    var dailyLeaderboards = JsonConvert.DeserializeObject<IEnumerable<DailyLeaderboard>>(Resources.DailyLeaderboards);
                    context.DailyLeaderboards.AddRange(dailyLeaderboards);

                    context.SaveChanges();
                }
            }
        }
    }
}
