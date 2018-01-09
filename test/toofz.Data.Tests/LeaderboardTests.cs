using System;
using System.Collections.Generic;
using Xunit;

namespace toofz.Data.Tests
{
    public class LeaderboardTests
    {
        public class LeaderboardIdProperty
        {
            [DisplayFact(nameof(Leaderboard.LeaderboardId))]
            public void GetsAndSetsLeaderboardId()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { LeaderboardId = 43895 };

                // Act -> Assert
                Assert.Equal(43895, leaderboard.LeaderboardId);
            }
        }

        public class EntriesProperty
        {
            [DisplayFact(nameof(Leaderboard.Entries))]
            public void GetsEntries()
            {
                // Arrange
                var leaderboard = new Leaderboard();

                // Act -> Assert
                Assert.IsAssignableFrom<List<Entry>>(leaderboard.Entries);
            }
        }

        public class LastUpdateProperty
        {
            [DisplayFact(nameof(Leaderboard.LastUpdate))]
            public void GetsAndSetsLastUpdate()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { LastUpdate = new DateTime(2017, 8, 28, 16, 27, 58) };

                // Act -> Assert
                Assert.Equal(new DateTime(2017, 8, 28, 16, 27, 58), leaderboard.LastUpdate);
            }
        }

        public class NameProperty
        {
            [DisplayFact(nameof(Leaderboard.Name))]
            public void GetsAndSetsName()
            {
                // Arrange
                var name = "myName";
                var leaderboard = new Leaderboard();

                // Act
                leaderboard.Name = name;
                var name2 = leaderboard.Name;

                // Assert
                Assert.Equal(name, name2);
            }
        }

        public class DisplayNameProperty
        {
            [DisplayFact(nameof(Leaderboard.DisplayName))]
            public void GetsAndSetsDisplayName()
            {
                // Arrange
                var displayName = "MyDisplayName";
                var leaderboard = new Leaderboard();

                // Act
                leaderboard.DisplayName = displayName;
                var displayName2 = leaderboard.DisplayName;

                // Assert
                Assert.Equal(displayName, displayName2);
            }
        }

        public class IsProductionProperty
        {
            [DisplayFact(nameof(Leaderboard.IsProduction))]
            public void GetsAndSetsIsProduction()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { IsProduction = true };

                // Act -> Assert
                Assert.True(leaderboard.IsProduction);
            }
        }

        public class ProductProperty
        {
            [DisplayFact(nameof(Leaderboard.Product))]
            public void GetsAndSetsProduct()
            {
                // Arrange
                var product = new Product(1, "myProduct", "MyProduct");

                // Act
                var leaderboard = new Leaderboard { Product = product };
                var product2 = leaderboard.Product;

                // Assert
                Assert.Same(product, product2);
            }
        }

        public class ProductIdProperty
        {
            [DisplayFact(nameof(Leaderboard.ProductId))]
            public void GetsAndSetsProductId()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { ProductId = 1 };

                // Act -> Assert
                Assert.Equal(1, leaderboard.ProductId);
            }
        }

        public class ModeProperty
        {
            [DisplayFact(nameof(Leaderboard.Mode))]
            public void GetsAndSetsMode()
            {
                // Arrange
                var mode = new Mode(1, "myMode", "MyMode");

                // Act
                var leaderboard = new Leaderboard { Mode = mode };
                var mode2 = leaderboard.Mode;

                // Assert
                Assert.Same(mode, mode2);
            }
        }

        public class ModeIdProperty
        {
            [DisplayFact(nameof(Leaderboard.ModeId))]
            public void GetsAndSetsModeId()
            {
                // Arrange
                var modeId = 1;
                var leaderboard = new Leaderboard();

                // Act
                leaderboard.ModeId = modeId;
                var modeId2 = leaderboard.ModeId;

                // Assert
                Assert.Equal(modeId, modeId2);
            }
        }

        public class RunProperty
        {
            [DisplayFact(nameof(Leaderboard.Run))]
            public void GetsAndSetsRun()
            {
                // Arrange
                var run = new Run(1, "myRun", "MyRun");
                var leaderboard = new Leaderboard();

                // Act
                leaderboard.Run = run;
                var run2 = leaderboard.Run;

                // Assert
                Assert.Same(run, run2);
            }
        }

        public class RunIdProperty
        {
            [DisplayFact(nameof(Leaderboard.RunId))]
            public void GetsAndSetsRunId()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { RunId = 2 };

                // Act -> Assert
                Assert.Equal(2, leaderboard.RunId);
            }
        }

        public class CharacterProperty
        {
            [DisplayFact(nameof(Leaderboard.Character))]
            public void GetsAndSetsCharacter()
            {
                // Arrange
                var character = new Character(1, "myCharacter", "MyCharacter");
                var leaderboard = new Leaderboard();

                // Act
                leaderboard.Character = character;
                var character2 = leaderboard.Character;

                // Assert
                Assert.Same(character, character2);
            }
        }

        public class CharacterIdProperty
        {
            [DisplayFact(nameof(Leaderboard.CharacterId))]
            public void GetsAndSetsCharacterId()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { CharacterId = 9 };

                // Act -> Assert
                Assert.Equal(9, leaderboard.CharacterId);
            }
        }

        public class IsCoOpProperty
        {
            [DisplayFact(nameof(Leaderboard.IsCoOp))]
            public void GetsAndSetsIsCoOp()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { IsCoOp = true };

                // Act -> Assert
                Assert.True(leaderboard.IsCoOp);
            }
        }

        public class IsCustomMusicProperty
        {
            [DisplayFact(nameof(Leaderboard.IsCustomMusic))]
            public void GetsAndSetsIsCustomMusic()
            {
                // Arrange -> Act
                var leaderboard = new Leaderboard { IsCustomMusic = true };

                // Act -> Assert
                Assert.True(leaderboard.IsCustomMusic);
            }
        }
    }
}
