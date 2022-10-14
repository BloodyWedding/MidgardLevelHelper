using MidgardLevelHelperCore.Extensions;
using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MidgardLevelHelperCore
{
    public class CharacterClass
    {
        private readonly LevelingSchema levelingSchema;
        private readonly IReadOnlyList<string> _baseSkills;
        private readonly IReadOnlyList<string> _exceptionalSkills;
        private readonly IReadOnlyList<string> _forbiddenSkills;

        public CharacterClass(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }

        public string Name { get; }
        public LevelingSchema LevelingSchema
        {
            get => levelingSchema;
            init
            {
                ArgumentNullException.ThrowIfNull(value);
                levelingSchema = value;
            }
        }
        public Resistances ResistanceBonuses { get; init; }
        public IReadOnlyList<string> BaseSkills
        {
            get => _baseSkills;
            init
            {
                ArgumentNullException.ThrowIfNull(value);
                EnsureContainsNoNullOrWhiteSpaces(value, nameof(value));
                var duplicates = value.GetNonUniqueNames();
                if (duplicates.Length > 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The following skills were specified multiple times: {string.Join(", ", duplicates)}");

                // TODO Need to ensure that added skill does not already exist in ExceptionalSkills or ForbiddenSkill
                _baseSkills = value;
            }
        }
        public IReadOnlyList<string> ExceptionalSkills
        {
            get => _exceptionalSkills;
            init
            {
                ArgumentNullException.ThrowIfNull(value);
                EnsureContainsNoNullOrWhiteSpaces(value, nameof(value));
                var duplicates = value.GetNonUniqueNames();
                if (duplicates.Length > 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The following skills were specified multiple times: {string.Join(", ", duplicates)}");

                // TODO Need to ensure that added skill does not already exist in BaseSkills or ForbiddenSkill
                _exceptionalSkills = value;
            }
        }
        public IReadOnlyList<string> ForbiddenSkills
        {
            get => _forbiddenSkills;
            init
            {
                ArgumentNullException.ThrowIfNull(value);
                EnsureContainsNoNullOrWhiteSpaces(value, nameof(value));
                var duplicates = value.GetNonUniqueNames();
                if (duplicates.Length > 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The following skills were specified multiple times: {string.Join(", ", duplicates)}");

                // TODO Need to ensure that added skill does not already exist in BaseSkills or ExceptionalSkills
                _forbiddenSkills = value;
            }
        }

        private void EnsureContainsNoNullOrWhiteSpaces(IReadOnlyList<string> value, string paramName)
        {
            if (value.Any(x => x is null || string.IsNullOrWhiteSpace(x)))
                throw new ArgumentOutOfRangeException(paramName, "NULL or 'All-Whitespace' elements are not allowed!");
        }
    }
}
