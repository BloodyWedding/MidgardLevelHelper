using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardLevelHelperCore
{
    public class CharacterClass
    {
        public CharacterClass(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        public string Name { get; }
        public LevelingSchema LevelingSchema { get; init; }
        public Resistances ResistanceBonuses { get; init; }
        public IReadOnlyList<string> BaseSkills { get; init; }
        public IReadOnlyList<string> ExceptionalSkills { get; init; }
        public IReadOnlyList<string> ForbiddenSkills { get; init; }
    }
}
