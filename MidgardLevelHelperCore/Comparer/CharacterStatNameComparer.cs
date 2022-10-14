using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MidgardLevelHelperCore.Primitives;

namespace MidgardLevelHelperCore.Comparer
{
    public class CharacterStatNameComparer : IEqualityComparer<CharacterStat>
    {
        public static CharacterStatNameComparer Default { get; } = new CharacterStatNameComparer();
        public bool Equals(CharacterStat x, CharacterStat y)
        {
            if (x is not null && y is not null)
            {
                return SkillsAndAttributesComparer.Default.Equals(x.Name, y.Name);
            }

            return x == null && y == null;
        }

        public int GetHashCode([DisallowNull] CharacterStat obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return SkillsAndAttributesComparer.Default.GetHashCode(obj.Name);
        }
    }
}
