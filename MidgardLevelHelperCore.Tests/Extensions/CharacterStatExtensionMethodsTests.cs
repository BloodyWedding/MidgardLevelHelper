using MidgardLevelHelperCore.Extensions;
using MidgardLevelHelperCore.Primitives;
using Xunit;

namespace MidgardLevelHelperCore.Tests.Extensions
{
    public class CharacterStatExtensionMethodsTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new[]
            {
                new TestData
                {
                    Input= new[]
                    {
                        new CharacterStat("A", 1),
                        new CharacterStat("A", 2)
                    },
                    ExpectedResult = new []{"A"}
                }
            };

            yield return new[]
            {
                new TestData
                {
                    Input= new[]
                    {
                        new CharacterStat("A", 1),
                        new CharacterStat("B", 2),
                        new CharacterStat("A", 3)
                    },
                    ExpectedResult = new []{"A"}
                }
            };

            yield return new[]
            {
                new TestData
                {
                    Input= new[]
                    {
                        new CharacterStat("A", 1),
                        new CharacterStat("a", 2),
                    },
                    ExpectedResult = new []{"A"}
                }
            };

            yield return new[]
            {
                new TestData
                {
                    Input= new[]
                    {
                        new CharacterStat("A", 1),
                        new CharacterStat("c", 2),
                        new CharacterStat("a", 3)
                    },
                    ExpectedResult = new []{"A"}
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void GetNonUniqueNames_WithDuplicates_ReturnsCorrectResult(TestData testData)
        {
            var result = testData.Input.GetNonUniqueCharacterStatNames();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(testData.ExpectedResult, result);
        }

        [Fact]
        public void GetNonUniqueNames_WithEmptyInput_ReturnsEmptyArray()
        {
            var testValue = new CharacterStat[0];
            var result = testValue.GetNonUniqueCharacterStatNames();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetNonUniqueNames_WithNoDuplicates_ReturnsEmptyArray()
        {
            var testValue = new[]
            {
                new CharacterStat("A", 1),
                new CharacterStat("B", 2)
            };
            var result = testValue.GetNonUniqueCharacterStatNames();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetNonUniqueNames_WithNullParameter_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = CharacterStatExtensionMethods.GetNonUniqueCharacterStatNames<CharacterStat>(null));
            Assert.Equal("characterStats", exception.ParamName);
        }

        public class TestData
        {
            public string[] ExpectedResult { get; set; } = Array.Empty<string>();
            public CharacterStat[] Input { get; set; } = Array.Empty<CharacterStat>();

            public override string ToString()
            {
                return $"Input: {string.Join(", ", Input.Select(x => x.Name))} => Expected: {string.Join(", ", ExpectedResult)}";
            }
        }
    }
}