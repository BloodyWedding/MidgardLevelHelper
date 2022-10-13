using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;

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
        public LevelingSchema LevelingSchema { get; init; } // TODO Prevent NULL
        public Resistances ResistanceBonuses { get; init; }
        public IReadOnlyList<string> BaseSkills { get; init; } // TODO Prevent duplicate entries
        public IReadOnlyList<string> ExceptionalSkills { get; init; } // TODO Prevent duplicate entries
        public IReadOnlyList<string> ForbiddenSkills { get; init; } // TODO Prevent duplicate entries
    }
}
