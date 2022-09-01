using System;

namespace MidgardLevelHelperCore
{
    public class CharacterClass
    {
        public CharacterClass(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        public string Name { get; }
        public float WeaponFactor { get; init; }
    }
}
