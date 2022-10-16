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

        // TODO Add opposite implicit operator? (TotalExperiencePoints to uint)

        public uint Value { get; set; }

        // TODO Recommended: Implement equality comparison to improve performance: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
    }
}
