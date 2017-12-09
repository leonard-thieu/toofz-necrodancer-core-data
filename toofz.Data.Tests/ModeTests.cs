using System;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class ModeTests
    {
        public class Constructor
        {
            [DisplayFact("Name", nameof(ArgumentNullException))]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var modeId = 1;
                string name = null;
                var displayName = "myDisplayName";

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Mode(modeId, name, displayName);
                });
            }

            [DisplayFact("DisplayName", nameof(ArgumentNullException))]
            public void DisplayNameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var modeId = 1;
                var name = "myName";
                string displayName = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Mode(modeId, name, displayName);
                });
            }

            [DisplayFact(nameof(Mode))]
            public void ReturnsMode()
            {
                // Arrange
                var modeId = 1;
                var name = "myName";
                var displayName = "myDisplayName";

                // Act
                var mode = new Mode(modeId, name, displayName);

                // Assert
                Assert.IsAssignableFrom<Mode>(mode);
            }

            [DisplayFact(nameof(Mode.ModeId))]
            public void SetsModeId()
            {
                // Arrange
                var modeId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var mode = new Mode(modeId, name, displayName);

                // Act
                var modeId2 = mode.ModeId;

                // Assert
                Assert.Equal(modeId, modeId2);
            }

            [DisplayFact(nameof(Mode.Name))]
            public void SetsName()
            {
                // Arrange
                var modeId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var mode = new Mode(modeId, name, displayName);

                // Act
                var name2 = mode.Name;

                // Assert
                Assert.Equal(name, name2);
            }

            [DisplayFact(nameof(Mode.DisplayName))]
            public void SetsDisplayName()
            {
                // Arrange
                var modeId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var mode = new Mode(modeId, name, displayName);

                // Act
                var displayName2 = mode.DisplayName;

                // Assert
                Assert.Equal(displayName, displayName2);
            }
        }
    }
}
