using System;

namespace MidgardLevelHelperCore
{
    public class Weapon
    {
        private readonly WeaponCategory _weaponCategory;

        public Weapon(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }
        public string Name { get; }

        public byte Difficulty { get; init; }
        public byte RequiredStrength { get; init; }
        public byte RequiredDexterity { get; init; }
        public WeaponCategory WeaponCategory
        {
            get => _weaponCategory;
            init // TODO Eher im ctor, da es nicht NULL sein sollte (und aktuell so vergessen werden kann)
            {
                ArgumentNullException.ThrowIfNull(value);
                _weaponCategory = value;
            }
        }
    }
}
