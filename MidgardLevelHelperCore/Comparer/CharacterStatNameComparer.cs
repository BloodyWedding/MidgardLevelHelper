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
                return Equals(x.Name, y.Name);
            }

            return x == null && y == null;
        }

        public int GetHashCode([DisallowNull] CharacterStat obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
