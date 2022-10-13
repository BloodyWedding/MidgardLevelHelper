using MidgardLevelHelperCore.Primitives;
using System.Collections.Generic;

namespace MidgardLevelHelperCore
{
    public class Skill
    {
        public string Name { get; }
        public IReadOnlyList<CharacterStat> Requirements{ get; init; } // TODO Prevent duplicate entries and NULL
        public byte StartingLevel { get; init; }
        public bool CanImprove { get; init; }
        public TotalExperiencePoints Cost { get; init; }
    }
}
