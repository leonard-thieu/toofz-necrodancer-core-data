using System;
using Xunit;

namespace toofz.Data.Tests
{
    public class CharacterTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var characterId = 1;
                string name = null;
                var displayName = "myDisplayName";

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Character(characterId, name, displayName);
                });
            }

            [DisplayFact("DisplayName", nameof(ArgumentNullException))]
            public void DisplayNameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var characterId = 1;
                var name = "myName";
                string displayName = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Character(characterId, name, displayName);
                });
            }

            [DisplayFact(nameof(Character))]
            public void ReturnsCharacter()
            {
                // Arrange
                var characterId = 1;
                var name = "myName";
                var displayName = "myDisplayName";

                // Act
                var character = new Character(characterId, name, displayName);

                // Assert
                Assert.IsAssignableFrom<Character>(character);
            }

            [DisplayFact(nameof(Character.CharacterId))]
            public void SetsCharacterId()
            {
                // Arrange
                var characterId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var character = new Character(characterId, name, displayName);

                // Act
                var characterId2 = character.CharacterId;

                // Assert
                Assert.Equal(characterId, characterId2);
            }

            [DisplayFact(nameof(Character.Name))]
            public void SetsName()
            {
                // Arrange
                var characterId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var character = new Character(characterId, name, displayName);

                // Act
                var name2 = character.Name;

                // Assert
                Assert.Equal(name, name2);
            }

            [DisplayFact(nameof(Character.DisplayName))]
            public void SetsDisplayName()
            {
                // Arrange
                var characterId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var character = new Character(characterId, name, displayName);

                // Act
                var displayName2 = character.DisplayName;

                // Assert
                Assert.Equal(displayName, displayName2);
            }
        }
    }
}
