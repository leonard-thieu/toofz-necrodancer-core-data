using System;
using Xunit;

namespace toofz.Data.Tests
{
    public class RunTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var runId = 1;
                string name = null;
                var displayName = "myDisplayName";

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Run(runId, name, displayName);
                });
            }

            [DisplayFact("DisplayName", nameof(ArgumentNullException))]
            public void DisplayNameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var runId = 1;
                var name = "myName";
                string displayName = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Run(runId, name, displayName);
                });
            }

            [DisplayFact(nameof(Run))]
            public void ReturnsRun()
            {
                // Arrange
                var runId = 1;
                var name = "myName";
                var displayName = "myDisplayName";

                // Act
                var run = new Run(runId, name, displayName);

                // Assert
                Assert.IsAssignableFrom<Run>(run);
            }

            [DisplayFact(nameof(Run.RunId))]
            public void SetsRunId()
            {
                // Arrange
                var runId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var run = new Run(runId, name, displayName);

                // Act
                var runId2 = run.RunId;

                // Assert
                Assert.Equal(runId, runId2);
            }

            [DisplayFact(nameof(Run.Name))]
            public void SetsName()
            {
                // Arrange
                var runId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var run = new Run(runId, name, displayName);

                // Act
                var name2 = run.Name;

                // Assert
                Assert.Equal(name, name2);
            }

            [DisplayFact(nameof(Run.DisplayName))]
            public void SetsDisplayName()
            {
                // Arrange
                var runId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var run = new Run(runId, name, displayName);

                // Act
                var displayName2 = run.DisplayName;

                // Assert
                Assert.Equal(displayName, displayName2);
            }
        }
    }
}
