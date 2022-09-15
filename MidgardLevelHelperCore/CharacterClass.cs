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
        //TODO Grundfähigkeit & Ausnahmefähigkeit definieren
    }
}
