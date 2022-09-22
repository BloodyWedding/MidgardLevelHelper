using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardLevelHelperCore
{
    public class Character
    {
        public Character(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        public string Name { get; }
        public CharacterClass Class { get; init; }
        public List<EditableCharacterStat> Skills { get; init; }
        public IReadOnlyList<EditableCharacterStat> Attributes { get; init; }
    }
}
