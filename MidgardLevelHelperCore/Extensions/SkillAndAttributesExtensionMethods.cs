using MidgardLevelHelperCore.Comparer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MidgardLevelHelperCore.Extensions
{
    internal static class SkillAndAttributesExtensionMethods
    {
        public static string[] GetNonUniqueNames(this IEnumerable<string> names)
        {
            ArgumentNullException.ThrowIfNull(names);

            return names.GroupBy(stat => stat, SkillsAndAttributesComparer.Default)
                .Where(group => group.Count() > 1)
                .Select(x => x.Key)
                .ToArray();
        }
    }
}