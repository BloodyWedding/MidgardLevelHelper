using System.Diagnostics;

namespace MidgardLevelHelperCore.Primitives
{
    [DebuggerDisplay("{Value}")]
    public struct TotalExperiencePoints
    {
        public uint Value { get; set; }
    }
}
