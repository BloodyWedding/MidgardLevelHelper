using MidgardLevelHelperCore.Primitives;
using Xunit;

namespace MidgardLevelHelperCore.Tests.Primitives
{
    public class TotalExperiencePointsTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(uint.MinValue)]
        [InlineData(uint.MaxValue)]
        public void ImplicitCastOperator_FromUint_ToTotalExperiencePoints_Works(uint val)
        {
            // Implicit Operator call!
            // Do not change variable declaration to "var"! Otherwise it will no longer be testing the implicit cast operator!
            TotalExperiencePoints tep = val;
            Assert.Equal(val, tep.Value);
        }
    }
}
