namespace MidgardLevelHelperCore.Primitives
{
    public struct Resistances
    {
        public byte Psychic { get; init; }
        public byte Physical { get; init; }
        public byte Environmental { get; init; }

        // TODO Recommended: Implement equality comparison to improve performance: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
    }
}
