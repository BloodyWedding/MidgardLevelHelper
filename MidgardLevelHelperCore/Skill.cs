using MidgardLevelHelperCore.Extensions;
using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;

namespace MidgardLevelHelperCore
{
    public class Skill
    {
        private readonly IReadOnlyList<CharacterStat> _requirements;

        public Skill(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }
        public string Name { get; }

        public IReadOnlyList<CharacterStat> Requirements
        {
            get => _requirements;
            init
            {
                ArgumentNullException.ThrowIfNull(value);
                var duplicates = value.GetNonUniqueCharacterStatNames();
                if (duplicates.Length > 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The following requirements were specified multiple times: {string.Join(", ", duplicates)}");

                _requirements = value;
            }
        }
        public byte StartingLevel { get; init; }
        public bool CanImprove { get; init; }
        public TotalExperiencePoints Cost { get; init; }
    }
}
