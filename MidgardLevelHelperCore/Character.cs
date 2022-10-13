using MidgardLevelHelperCore.Comparer;
using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MidgardLevelHelperCore
{
    public class Character
    {
        private IReadOnlyList<EditableCharacterStat> _attributes;

        public Character(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        public string Name { get; }
        public CharacterClass Class { get; init; } // TODO Prevent NULL
        public short HealthPoints { get; init; }
        public HashSet<EditableCharacterStat> Skills { get; } = new HashSet<EditableCharacterStat>(CharacterStatNameComparer.Default);
        public IReadOnlyList<EditableCharacterStat> Attributes
        {
            get => _attributes;

            init
            {
                ArgumentNullException.ThrowIfNull(nameof(value));
                EnsureUniqueAttributes(value);
                _attributes = value;
            }
        }

        private void EnsureUniqueAttributes(IReadOnlyList<EditableCharacterStat> value)
        {
            var duplicates = value.GroupBy(stat => stat, CharacterStatNameComparer.Default)
                .Where(group => group.Count() > 1)
                .Select(x => x.Key.Name)
                .ToArray();
            if (duplicates.Any())
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"The following Attributes were specified multiple times: {string.Join(", ", duplicates)}");
            }
        }
    }
}
