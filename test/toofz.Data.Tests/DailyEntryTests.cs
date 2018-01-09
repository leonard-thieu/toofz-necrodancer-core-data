using Xunit;

namespace toofz.Data.Tests
{
    public class DailyEntryTests
    {
        public class LeaderboardIdProperty
        {
            [DisplayFact(nameof(DailyEntry.LeaderboardId))]
            public void GetsAndSetsLeaderboardId()
            {
                // Arrange -> Act
                var dailyEntry = new DailyEntry { LeaderboardId = 234 };

                // Act -> Assert
                Assert.Equal(234, dailyEntry.LeaderboardId);
            }
        }

        public class LeaderboardProperty
        {
            [DisplayFact(nameof(DailyEntry.Leaderboard))]
            public void GetsAndSetsLeaderboard()
            {
                // Arrange -> Act
                var leaderboard = new DailyLeaderboard();
                var dailyEntry = new DailyEntry { Leaderboard = leaderboard };

                // Act -> Assert
                Assert.Equal(leaderboard, dailyEntry.Leaderboard);
            }
        }

        public class RankProperty
        {
            [DisplayFact(nameof(DailyEntry.Rank))]
            public void GetsAndSetsRank()
            {
                // Arrange -> Act
                var dailyEntry = new DailyEntry { Rank = 345 };

                // Act -> Assert
                Assert.Equal(345, dailyEntry.Rank);
            }
        }

        public class SteamIdProperty
        {
            [DisplayFact(nameof(DailyEntry.SteamId))]
            public void GetsAndSetsSteamId()
            {
                // Arrange -> Act
                var dailyEntry = new DailyEntry { SteamId = 765 };

                // Act -> Assert
                Assert.Equal(765L, dailyEntry.SteamId);

            }
        }

        public class PlayerProperty
        {
            [DisplayFact(nameof(DailyEntry.Player))]
            public void GetsAndSetsPlayer()
            {
                // Arrange -> Act
                var player = new Player();
                var dailyEntry = new DailyEntry { Player = player };

                // Act -> Assert
                Assert.Equal(player, dailyEntry.Player);
            }
        }

        public class ReplayIdProperty
        {
            [DisplayFact(nameof(DailyEntry.ReplayId))]
            public void GetsAndSetsReplayId()
            {
                // Arrange -> Act
                var dailyEntry = new DailyEntry { ReplayId = 9082374 };

                // Act -> Assert
                Assert.Equal(9082374L, dailyEntry.ReplayId);
            }
        }

        public class ReplayProperty
        {
            [DisplayFact(nameof(DailyEntry.Replay))]
            public void GetsAndSetsReplay()
            {
                // Arrange
                var replay = new Replay();
                var dailyEntry = new DailyEntry();

                // Act
                dailyEntry.Replay = replay;
                var replay2 = dailyEntry.Replay;

                // Assert
                Assert.Same(replay, replay2);
            }
        }

        public class ScoreProperty
        {
            [DisplayFact(nameof(DailyEntry.Score))]
            public void GetsAndSetsScore()
            {
                // Arrange -> Act
                var dailyEntry = new DailyEntry { Score = 10 };

                // Act -> Assert
                Assert.Equal(10, dailyEntry.Score);
            }
        }

        public class ZoneProperty
        {
            [DisplayFact(nameof(DailyEntry.Zone))]
            public void GetsAndSetsZone()
            {
                // Arrange -> Act
                var dailyEntry = new DailyEntry { Zone = 1 };

                // Act -> Assert
                Assert.Equal(1, dailyEntry.Zone);
            }
        }

        public class LevelProperty
        {
            [DisplayFact(nameof(DailyEntry.Level))]
            public void GetsAndSetsLevel()
            {
                // Arrange -> Act
                var dailyEntry = new DailyEntry { Level = 2 };

                // Act -> Assert
                Assert.Equal(2, dailyEntry.Level);
            }
        }
    }
}
