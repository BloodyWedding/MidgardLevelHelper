using MidgardLevelHelperCore.Primitives;
using Xunit;

namespace MidgardLevelHelperCore.Tests
{
    public class SkillTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_NameCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string name)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new Skill(name));
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void Requirements_DuplicatesCanNotBeSet_ThrowsArgumentOutOfRangeException()
        {
            const string Skill1 = "Skill 1";
            var requirements = new List<CharacterStat>
            {
                new CharacterStat(Skill1, 1),
                new CharacterStat(Skill1, 50),
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Skill("Test")
            {
                Requirements = requirements
            });
            Assert.Equal("The following requirements were specified multiple times: Skill 1 (Parameter 'value')", exception.Message);
        }

        [Fact]
        public void Requirements_NullCanNotBeSet_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new Skill("Test")
            {
                Requirements = null
            });
            Assert.Equal("value", exception.ParamName);
        }
    }
}