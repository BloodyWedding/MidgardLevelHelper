using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardLevelHelperCore.Primitives
{
    public class EditableCharacterStat : CharacterStat
    {
        public EditableCharacterStat(string name, uint value) : base(name, value)
        {
            
        }
        public new uint Value { get => base.Value; set => base.Value = value; }
    }
}
