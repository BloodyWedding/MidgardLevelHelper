using MidgardLevelHelperCore.Extensions;
using Xunit;

namespace MidgardLevelHelperCore.Tests.Extensions
{
    public class SkillsAndAttributesExtensionMethodsTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new[]
            {
                new TestData
                {
                    Input= new[] { "", "" },
                    ExpectedResult = new []{""}
                }
            };

            yield return new[]
            {
                new TestData
                {
                    Input= new[] { "A", "A" },
                    ExpectedResult = new []{"A"}
                }
            };

            yield return new[]
            {
                new TestData
                {
                    Input= new[] {"A", "B", "A" },
                    ExpectedResult = new []{"A"}
                }
            };

            yield return new[]
            {
                new TestData
                {
                    Input= new[] {"A", "a" },
                    ExpectedResult = new []{"A"}
                }
            };

            yield return new[]
            {
                new TestData
                {
                    Input= new[] {"A", "C", "a" },
                    ExpectedResult = new []{"A"}
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void GetNonUniqueNames_WithDuplicates_ReturnsCorrectResult(TestData testData)
        {
            var result = testData.Input.GetNonUniqueNames();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(testData.ExpectedResult, result);
        }

        [Fact]
        public void GetNonUniqueNames_WithEmptyInput_ReturnsEmptyArray()
        {
            var testValue = new string[0];
            var result = testValue.GetNonUniqueNames();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetNonUniqueNames_WithNoDuplicates_ReturnsEmptyArray()
        {
            var testValue = new[] { "A", "B" };
            var result = testValue.GetNonUniqueNames();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetNonUniqueNames_WithNullParameter_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = SkillAndAttributesExtensionMethods.GetNonUniqueNames(null));
            Assert.Equal("names", exception.ParamName);
        }

        public class TestData
        {
            public string[] ExpectedResult { get; set; } = Array.Empty<string>();
            public string[] Input { get; set; } = Array.Empty<string>();

            public override string ToString()
            {
                return $"Input: {string.Join(", ", Input)} => Expected: {string.Join(", ", ExpectedResult)}";
            }
        }
    }
}