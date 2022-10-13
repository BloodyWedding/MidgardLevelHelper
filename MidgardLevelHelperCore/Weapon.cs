using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardLevelHelperCore
{
    public class Weapon
    {
        public string Name { get; init; }
        public byte Difficulty { get; init; }
        public byte RequiredStrength { get; init; }
        public byte RequiredDexterity { get; init; }
        public WeaponCategory WeaponCategory { get; init; } // TODO Prevent NULL

    }
}
