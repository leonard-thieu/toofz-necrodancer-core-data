using System;
using System.Collections.Generic;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class PlayerTests
    {
        public class SteamIdProperty
        {
            [DisplayFact(nameof(Player.SteamId))]
            public void GetsAndSetsSteamId()
            {
                // Arrange -> Act
                var player = new Player { SteamId = 34897238 };

                // Act -> Assert
                Assert.Equal(34897238L, player.SteamId);
            }
        }


        public class ExistsProperty
        {
            [DisplayFact(nameof(Player.Exists))]
            public void GetsAndSetsExists()
            {
                // Arrange -> Act
                var player = new Player { Exists = true };

                // Act - Assert
                Assert.True(player.Exists);
            }
        }


        public class NameProperty
        {
            [DisplayFact(nameof(Player.Name))]
            public void GetsAndSetsName()
            {
                // Arrange -> Act
                var player = new Player { Name = "MYnAME" };

                // Act -> Assert
                Assert.Equal("MYnAME", player.Name);
            }
        }


        public class AvatarProperty
        {
            [DisplayFact(nameof(Player.Avatar))]
            public void GetsAndSetsAvatar()
            {
                // Arrange -> Act
                var player = new Player { Avatar = "http://my.avatar.url/" };

                // Act -> Assert
                Assert.Equal("http://my.avatar.url/", player.Avatar);
            }
        }


        public class LastUpdateProperty
        {
            [DisplayFact(nameof(Player.LastUpdate))]
            public void GetsAndSetsLastUpdate()
            {
                // Arrange -> Act
                var player = new Player { LastUpdate = new DateTime(2017, 8, 30, 18, 53, 49) };

                // Act -> Assert
                Assert.Equal(new DateTime(2017, 8, 30, 18, 53, 49), player.LastUpdate);
            }
        }


        public class EntriesProperty
        {
            [DisplayFact(nameof(Player.Entries))]
            public void GetsEntries()
            {
                // Arrange
                var player = new Player();

                // Act -> Assert
                Assert.IsAssignableFrom<List<Entry>>(player.Entries);
            }
        }
    }
}
