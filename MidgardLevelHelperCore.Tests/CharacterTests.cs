using MidgardLevelHelperCore.Primitives;
using Xunit;

namespace MidgardLevelHelperCore.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void Attributes_CanNotBeNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new Character("My Test Character") { Attributes = null };
            });
        }

        [Fact]
        public void Attributes_DuplicateAttributes_CanNotBeSet_ThrowsArgumentOutOfRangeException()
        {
            const string Attribute1 = "Attribute 1";
            var duplicateAttributesList = new List<EditableCharacterStat>()
            {
                new EditableCharacterStat(Attribute1, 1),
                new EditableCharacterStat(Attribute1, 50),
            };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _ = new Character("My Test Character") { Attributes = duplicateAttributesList };
            });
            Assert.Equal("The following attributes were specified multiple times: Attribute 1 (Parameter 'value')", exception.Message);
        }

        [Fact]
        public void Class_NullCanNotBeSet_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new Character("My Test Character") { Class = null };
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_NameCanNotBeNullOrWhiteSpace_ThrowsArgumentNullException(string name)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _ = new Character(name));
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void Skills_DuplicateSkill_CanNotBeAdded()
        {
            const string Skill1 = "Skill 1";
            var character = new Character("My Test Character");
            var wasAdded1 = character.Skills.Add(new EditableCharacterStat(Skill1, 1));
            Assert.True(wasAdded1);
            var wasAdded2 = character.Skills.Add(new EditableCharacterStat(Skill1, 10));
            Assert.False(wasAdded2);

            var skill = Assert.Single(character.Skills);
            Assert.Equal(Skill1, skill.Name);
            Assert.Equal((uint)1, skill.Value);
        }
    }
}