namespace MidgardLevelHelperCore.Primitives
{
    public struct SkillLevelCost
    {
        public byte SkillLevel { get; set; }
        public ushort Cost { get; set; }

        // TODO Recommended: Implement equality comparison to improve performance: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
    }
}
