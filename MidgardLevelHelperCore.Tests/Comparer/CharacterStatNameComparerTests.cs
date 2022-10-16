using MidgardLevelHelperCore.Comparer;
using MidgardLevelHelperCore.Primitives;
using Xunit;

namespace MidgardLevelHelperCore.Tests.Comparer
{
    public class CharacterStatNameComparerTests
    {
        [Fact]
        public void Equals_BothValuesNull_AreEqual()
        {
            Assert.True(CharacterStatNameComparer.Default.Equals(null, null));
        }

        [Fact]
        public void Equals_NullAndNonNull_AreNotEqual()
        {
            Assert.False(CharacterStatNameComparer.Default.Equals(null, new CharacterStat("Test", 1)));
            Assert.False(CharacterStatNameComparer.Default.Equals(new CharacterStat("Test", 1), null));
        }

        [Fact]
        public void Equals_SameStatName_DifferentCasing_AreEqual()
        {
            var stat1 = new CharacterStat("STAT 1", 1);
            var stat2 = new CharacterStat("stat 1", 10);
            Assert.True(CharacterStatNameComparer.Default.Equals(stat1, stat2));
            Assert.True(CharacterStatNameComparer.Default.Equals(stat2, stat1));
        }

        [Fact]
        public void Equals_SameStatName_SameCasing_AreEqual()
        {
            var stat1 = new CharacterStat("Stat 1", 1);
            var stat2 = new CharacterStat("Stat 1", 10);
            Assert.True(CharacterStatNameComparer.Default.Equals(stat1, stat2));
            Assert.True(CharacterStatNameComparer.Default.Equals(stat2, stat1));
        }

        [Fact]
        public void GetHashCode_NullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = CharacterStatNameComparer.Default.GetHashCode(null!));
        }

        [Fact]
        public void GetHashCode_SameStatName_DifferentCasing_AreEqual()
        {
            var stat1 = new CharacterStat("STAT 1", 1);
            var stat2 = new CharacterStat("stat 1", 10);
            var stat1HashCode = CharacterStatNameComparer.Default.GetHashCode(stat1);
            var stat2HashCode = CharacterStatNameComparer.Default.GetHashCode(stat2);
            Assert.Equal(stat1HashCode, stat2HashCode);
        }

        [Fact]
        public void GetHashCode_SameStatName_SameCasing_AreEqual()
        {
            var stat1 = new CharacterStat("Stat 1", 1);
            var stat2 = new CharacterStat("Stat 1", 10);
            var stat1HashCode = CharacterStatNameComparer.Default.GetHashCode(stat1);
            var stat2HashCode = CharacterStatNameComparer.Default.GetHashCode(stat2);
            Assert.Equal(stat1HashCode, stat2HashCode);
        }
    }
}