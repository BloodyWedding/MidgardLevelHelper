using Xunit;

namespace MidgardLevelHelperCore.Tests
{
    public class CharacterClassTests
    {
        [Fact]
        public void BaseSkills_DuplicatesCanNotBeSet_ThrowsArgumentOutOfRangeException()
        {
            const string Skill1 = "Skill 1";
            var skills = new List<string>
            {
                Skill1,
                Skill1,
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = new CharacterClass("Test")
            {
                BaseSkills = skills
            });
            Assert.Equal("The following skills were specified multiple times: Skill 1 (Parameter 'value')", exception.Message);
        }

        [Fact]
        public void BaseSkills_NullCanNotBeSet_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new CharacterClass("Test")
            {
                BaseSkills = null
            });
            Assert.Equal("value", exception.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BaseSkills_NullOrWhiteSpaceElementsCanNotBeSet_ThrowsArgumentOutOfRangeException(string invalidElement)
        {
            var skills = new List<string>
            {
                invalidElement,
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = new CharacterClass("Test")
            {
                BaseSkills = skills
            });
            Assert.Equal("NULL or 'All-Whitespace' elements are not allowed! (Parameter 'value')", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_NameCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string name)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new CharacterClass(name));
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void ExceptionalSkills_DuplicatesCanNotBeSet_ThrowsArgumentOutOfRangeException()
        {
            const string Skill1 = "Skill 1";
            var skills = new List<string>
            {
                Skill1,
                Skill1,
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = new CharacterClass("Test")
            {
                ExceptionalSkills = skills
            });
            Assert.Equal("The following skills were specified multiple times: Skill 1 (Parameter 'value')", exception.Message);
        }

        [Fact]
        public void ExceptionalSkills_NullCanNotBeSet_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new CharacterClass("Test")
            {
                ExceptionalSkills = null
            });
            Assert.Equal("value", exception.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ExceptionalSkills_NullOrWhiteSpaceElementsCanNotBeSet_ThrowsArgumentOutOfRangeException(string invalidElement)
        {
            var skills = new List<string>
            {
                invalidElement,
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = new CharacterClass("Test")
            {
                ExceptionalSkills = skills
            });
            Assert.Equal("NULL or 'All-Whitespace' elements are not allowed! (Parameter 'value')", exception.Message);
        }

        [Fact]
        public void ForbiddenSkills_DuplicatesCanNotBeSet_ThrowsArgumentOutOfRangeException()
        {
            const string Skill1 = "Skill 1";
            var skills = new List<string>
            {
                Skill1,
                Skill1,
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = new CharacterClass("Test")
            {
                ForbiddenSkills = skills
            });
            Assert.Equal("The following skills were specified multiple times: Skill 1 (Parameter 'value')", exception.Message);
        }

        [Fact]
        public void ForbiddenSkills_NullCanNotBeSet_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new CharacterClass("Test")
            {
                ForbiddenSkills = null
            });
            Assert.Equal("value", exception.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ForbiddenSkills_NullOrWhiteSpaceElementsCanNotBeSet_ThrowsArgumentOutOfRangeException(string invalidElement)
        {
            var skills = new List<string>
            {
                invalidElement,
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = new CharacterClass("Test")
            {
                ForbiddenSkills = skills
            });
            Assert.Equal("NULL or 'All-Whitespace' elements are not allowed! (Parameter 'value')", exception.Message);
        }

        [Fact]
        public void LevelingSchema_NullCanNotBeSet_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new CharacterClass("Test")
            {
                LevelingSchema = null
            });
            Assert.Equal("value", exception.ParamName);
        }
    }
}