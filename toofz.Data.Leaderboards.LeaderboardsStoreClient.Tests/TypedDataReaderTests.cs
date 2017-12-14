using System;
using System.Collections.Generic;
using Xunit;

namespace toofz.Data.Tests
{
    public class TypedDataReaderTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(TypedDataReader<TestDto>))]
            public void ReturnsTypedDataReader()
            {
                // Arrange
                var items = new List<TestDto>();

                // Act
                var reader = new TypedDataReader<TestDto>(TestDto.ColumnMappings, items);

                // Assert
                Assert.IsAssignableFrom<TypedDataReader<TestDto>>(reader);
            }
        }

        public class GetValueMethod
        {
            [DisplayFact]
            public void ReturnsValue()
            {
                // Arrange
                var items = new List<TestDto>
                {
                    new TestDto
                    {
                        KeyPart1 = "TEST",
                        KeyPart2 = 1,
                        Text = "some text here 1",
                        Number = 1,
                        Date = new DateTimeOffset(new DateTime(2010, 11, 14, 12, 0, 0), TimeSpan.FromHours(1)),
                    },
                };
                var reader = new TypedDataReader<TestDto>(TestDto.ColumnMappings, items);
                reader.Read();

                // Act
                var value = reader.GetValue(0);

                // Assert
                Assert.Equal("TEST", value);
            }
        }

        public class GetOrdinalMethod
        {
            [DisplayFact]
            public void ReturnsOrdinal()
            {
                // Arrange
                var items = new List<TestDto>
                {
                    new TestDto
                    {
                        KeyPart1 = "TEST",
                        KeyPart2 = 1,
                        Text = "some text here 1",
                        Number = 1,
                        Date = new DateTimeOffset(new DateTime(2010, 11, 14, 12, 0, 0), TimeSpan.FromHours(1)),
                    },
                };
                var reader = new TypedDataReader<TestDto>(TestDto.ColumnMappings, items);

                // Act
                var ordinal = reader.GetOrdinal("nullable_text");

                // Assert
                Assert.Equal(2, ordinal);
            }
        }

        public class FieldCountProperty
        {
            [DisplayFact]
            public void ReturnsFieldCount()
            {
                // Arrange
                var items = new List<TestDto>
                {
                    new TestDto
                    {
                        KeyPart1 = "TEST",
                        KeyPart2 = 1,
                        Text = "some text here 1",
                        Number = 1,
                        Date = new DateTimeOffset(new DateTime(2010, 11, 14, 12, 0, 0), TimeSpan.FromHours(1)),
                    },
                };
                var reader = new TypedDataReader<TestDto>(TestDto.ColumnMappings, items);

                // Act
                var fieldCount = reader.FieldCount;

                // Assert
                Assert.Equal(5, fieldCount);
            }
        }

        public class ReadMethod
        {
            [DisplayFact]
            public void ReadIsSuccessful_ReturnsTrue()
            {
                // Arrange
                var items = new List<TestDto>
                {
                    new TestDto
                    {
                        KeyPart1 = "TEST",
                        KeyPart2 = 1,
                        Text = "some text here 1",
                        Number = 1,
                        Date = new DateTimeOffset(new DateTime(2010, 11, 14, 12, 0, 0), TimeSpan.FromHours(1)),
                    },
                };
                var reader = new TypedDataReader<TestDto>(TestDto.ColumnMappings, items);

                // Act
                var isSuccessful = reader.Read();

                // Assert
                Assert.True(isSuccessful);
            }

            [DisplayFact]
            public void ReadIsNotSuccessful_ReturnsFalse()
            {
                // Arrange
                var items = new List<TestDto>
                {
                    new TestDto
                    {
                        KeyPart1 = "TEST",
                        KeyPart2 = 1,
                        Text = "some text here 1",
                        Number = 1,
                        Date = new DateTimeOffset(new DateTime(2010, 11, 14, 12, 0, 0), TimeSpan.FromHours(1)),
                    },
                };
                var reader = new TypedDataReader<TestDto>(TestDto.ColumnMappings, items);

                // Act
                reader.Read();
                var isSuccessful = reader.Read();

                // Assert
                Assert.False(isSuccessful);
            }
        }

        private class TestDto
        {
            public static IDictionary<string, string> ColumnMappings = new Dictionary<string, string>
            {
                [nameof(KeyPart1)] = "key_part_1",
                [nameof(KeyPart2)] = "key_part_2",
                [nameof(Text)] = "nullable_text",
                [nameof(Number)] = "nullable_number",
                [nameof(Date)] = "nullable_datetimeoffset",
            };

            public string KeyPart1 { get; set; }
            public short KeyPart2 { get; set; }
            public string Text { get; set; }
            public int Number { get; set; }
            public DateTimeOffset Date { get; set; }
        }
    }
}
