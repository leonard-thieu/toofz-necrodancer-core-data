using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class EntryTests
    {
        public class LeaderboardIdProperty
        {
            [DisplayFact(nameof(Entry.LeaderboardId))]
            public void GetsAndSetsLeaderboardId()
            {
                // Arrange -> Act
                var entry = new Entry { LeaderboardId = 123 };

                // Act -> Assert
                Assert.Equal(123, entry.LeaderboardId);
            }
        }

        public class LeaderboardProperty
        {
            [DisplayFact(nameof(Entry.Leaderboard))]
            public void GetsAndSetsLeaderboard()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard();
                var entry = new Entry { Leaderboard = leaderboard };

                // Act -> Assert
                Assert.Equal(leaderboard, entry.Leaderboard);
            }
        }

        public class RankProperty
        {
            [DisplayFact(nameof(Entry.Rank))]
            public void GetsAndSetsRank()
            {
                // Arrange -> Act
                var entry = new Entry { Rank = 321 };

                // Act -> Assert
                Assert.Equal(321, entry.Rank);
            }
        }

        public class SteamIdProperty
        {
            [DisplayFact(nameof(Entry.SteamId))]
            public void GetsAndSetsSteamId()
            {
                // Arrange -> Act
                var entry = new Entry { SteamId = 459687893 };

                // Act -> Assert
                Assert.Equal(459687893L, entry.SteamId);
            }
        }

        public class PlayerProperty
        {
            [DisplayFact(nameof(Entry.Player))]
            public void GetsAndSetsPlayer()
            {
                // Arrange -> Act
                var player = new Player();
                var entry = new Entry { Player = player };

                // Act -> Assert
                Assert.Equal(player, entry.Player);
            }
        }

        public class ReplayIdProperty
        {
            [DisplayFact(nameof(Entry.ReplayId))]
            public void GetsAndSetsReplayId()
            {
                // Arrange -> Act
                var entry = new Entry { ReplayId = 239847589234 };

                // Act -> Assert
                Assert.Equal(239847589234L, entry.ReplayId);
            }
        }

        public class ReplayProperty
        {
            [DisplayFact(nameof(Entry.Replay))]
            public void GetsAndSetsReplay()
            {
                // Arrange
                var replay = new Replay();
                var entry = new Entry();

                // Act
                entry.Replay = replay;
                var replay2 = entry.Replay;

                // Assert
                Assert.Same(replay, replay2);
            }
        }

        public class ScoreProperty
        {
            [DisplayFact(nameof(Entry.Score))]
            public void GetsAndSetsScore()
            {
                // Arrange -> Act
                var entry = new Entry { Score = 10 };

                // Act -> Assert
                Assert.Equal(10, entry.Score);
            }
        }

        public class ZoneProperty
        {
            [DisplayFact(nameof(Entry.Zone))]
            public void GetsAndSetsZone()
            {
                // Arrange -> Act
                var entry = new Entry { Zone = 1 };

                // Act -> Assert
                Assert.Equal(1, entry.Zone);
            }
        }

        public class LevelProperty
        {
            [DisplayFact(nameof(Entry.Level))]
            public void GetsAndSetsLevel()
            {
                // Arrange -> Act
                var entry = new Entry { Level = 2 };

                // Act -> Assert
                Assert.Equal(2, entry.Level);
            }
        }
    }
}
