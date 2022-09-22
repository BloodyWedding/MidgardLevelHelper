using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardLevelHelperCore.Primitives
{
    public class CharacterStat
    {
        public CharacterStat(string name, uint value)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public uint Value { get; protected set; }
    }
}
