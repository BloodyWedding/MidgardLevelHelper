using MidgardLevelHelperCore.Comparer;
using MidgardLevelHelperCore.Extensions;
using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;

namespace MidgardLevelHelperCore
{
    public class Character
    {
        private readonly IReadOnlyList<EditableCharacterStat> _attributes;
        private readonly CharacterClass _class;

        public Character(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        public string Name { get; }
        public CharacterClass Class
        {
            get => _class;
            init // TODO Eher im ctor, da es nicht NULL sein sollte (und aktuell so vergessen werden kann)
            {
                ArgumentNullException.ThrowIfNull(value);
                _class = value;
            }
        }
        public short HealthPoints { get; set; }
        public HashSet<EditableCharacterStat> Skills { get; } = new HashSet<EditableCharacterStat>(CharacterStatNameComparer.Default);
        public IReadOnlyList<EditableCharacterStat> Attributes
        {
            get => _attributes;

            init // TODO Eher im ctor, da es nicht NULL sein sollte (und aktuell so vergessen werden kann) alternativ kann diese Liste tatsächlich fix initialisiert werden da sie ja immer die gleichen Attribute beinahltet

            {
                ArgumentNullException.ThrowIfNull(value);
                var duplicates = value.GetNonUniqueCharacterStatNames();
                if(duplicates.Length > 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The following attributes were specified multiple times: {string.Join(", ", duplicates)}");

                _attributes = value;
            }
        }
    }
}
