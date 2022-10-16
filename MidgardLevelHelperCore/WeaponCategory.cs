using MidgardLevelHelperCore.Primitives;
using System;
using System.Diagnostics;

namespace MidgardLevelHelperCore
{
    [DebuggerDisplay("{Name} {Cost}")]
    public class WeaponCategory
    {
        public WeaponCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }
        public string Name { get; }

        public TotalExperiencePoints Cost { get; init; }
    }
}
