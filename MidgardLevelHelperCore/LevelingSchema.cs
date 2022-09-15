using System;

namespace MidgardLevelHelperCore
{
    public class LevelingSchema
    {
        public LevelingSchema(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException(nameof(type));
            }
            Type = type;
        }

        public string Type { get; }
        public float WeaponFactor { get; init; }
    }
}
