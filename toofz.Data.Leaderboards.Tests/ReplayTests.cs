using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class ReplayTests
    {
        public class ReplayIdProperty
        {
            [DisplayFact(nameof(Replay.ReplayId))]
            public void GetsAndSetsReplayId()
            {
                // Arrange -> Act
                var replay = new Replay { ReplayId = 32874823748 };

                // Act -> Assert
                Assert.Equal(32874823748L, replay.ReplayId);
            }
        }


        public class ErrorCodeProperty
        {
            [DisplayFact(nameof(Replay.ErrorCode))]
            public void GetsAndSetsErrorCode()
            {
                // Arrange -> Act
                var replay = new Replay { ErrorCode = 23847 };

                // Act -> Assert
                Assert.Equal(23847, replay.ErrorCode);
            }
        }


        public class SeedProperty
        {
            [DisplayFact(nameof(Replay.Seed))]
            public void GetsAndSetsSeed()
            {
                // Arrange -> Act
                var replay = new Replay { Seed = 234235 };

                // Act -> Assert
                Assert.Equal(234235, replay.Seed);
            }
        }


        public class VersionProperty
        {
            [DisplayFact(nameof(Replay.Version))]
            public void GetsAndSetsVersion()
            {
                // Arrange -> Act
                var replay = new Replay { Version = 12 };

                // Act -> Assert
                Assert.Equal(12, replay.Version);
            }
        }


        public class KilledByProperty
        {
            [DisplayFact(nameof(Replay.KilledBy))]
            public void GetsAndSetsKilledBy()
            {
                // Arrange -> Act
                var replay = new Replay { KilledBy = "A scary enemy" };

                // Act -> Assert
                Assert.Equal("A scary enemy", replay.KilledBy);
            }
        }


        public class UriProperty
        {
            [DisplayFact(nameof(Replay.Uri))]
            public void GetsAndSetsUri()
            {
                // Arrange -> Act
                var replay = new Replay { Uri = "http://example.org/" };

                // Act -> Assert
                Assert.Equal("http://example.org/", replay.Uri);
            }
        }
    }
}
