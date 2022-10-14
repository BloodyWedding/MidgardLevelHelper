using MidgardLevelHelperCore.Comparer;
using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MidgardLevelHelperCore.Extensions
{
    internal static class CharacterStatExtensionMethods
    {
        public static string[] GetNonUniqueCharacterStatNames<T>(this IEnumerable<T> characterStats) where T : CharacterStat
        {
            ArgumentNullException.ThrowIfNull(characterStats);

            return characterStats.GroupBy(stat => stat, CharacterStatNameComparer.Default)
                .Where(group => group.Count() > 1)
                .Select(x => x.Key.Name)
                .ToArray();
        }
    }
}