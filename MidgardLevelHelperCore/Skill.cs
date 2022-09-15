using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardLevelHelperCore
{
    public class Skill
    {
        public string Name { get; }
        public IReadOnlyList<CharacterStat> Requirements{ get; init; }
        public byte StartingLevel { get; init; }
        public bool CanImprove { get; init; }
        public TotalExperiencePoints Cost { get; init; }
    }
}
