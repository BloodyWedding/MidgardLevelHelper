using System.Diagnostics;

namespace MidgardLevelHelperCore.Primitives
{
    [DebuggerDisplay("{Value}")]
    public struct TotalExperiencePoints
    {
        public static implicit operator TotalExperiencePoints(uint value) 
        { 
            return new TotalExperiencePoints 
            { 
                Value = value 
            }; 
        } 
        public uint Value { get; set; }
    }
}
