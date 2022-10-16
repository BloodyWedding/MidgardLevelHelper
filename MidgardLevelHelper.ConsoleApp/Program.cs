using MidgardLevelHelperCore;
using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MidgardLevelHelper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var fighter = new LevelingSchema("Kämpfer")
            {
                WeaponFactor = 0.5f
            };

            var mage = new LevelingSchema("Zauberer")
            {
                WeaponFactor = 2f
            };

            var oneHandSwords = new WeaponCategory("Einhandschwerter")
            {
                Cost = 600
            };
            var stabbingWeapons = new WeaponCategory("Stichwaffe")
            {
                Cost = 400
            };
            var shields = new WeaponCategory("Schilde")
            {
                Cost = 300
            };

            var longsword = new Weapon("Langschwert")
            {
                Difficulty = 5,
                RequiredDexterity = 21,
                RequiredStrength = 31,
                WeaponCategory = oneHandSwords
            };

            var buckler = new Weapon("Buckler")
            {
                Difficulty = 1,
                RequiredDexterity = 61,
                RequiredStrength = 1,
                WeaponCategory = shields
            };

            var dagger = new Weapon("Dolch")
            {
                Difficulty = 2,
                RequiredDexterity = 1,
                RequiredStrength = 1,
                WeaponCategory = stabbingWeapons
            };

            var offensiveWeaponSkillLevels = new List<SkillLevelCost>
            {
                new SkillLevelCost { SkillLevel = 6, Cost = 6 },
                new SkillLevelCost { SkillLevel = 7, Cost = 6 },
                new SkillLevelCost { SkillLevel = 8, Cost = 10 },
                new SkillLevelCost { SkillLevel = 9, Cost = 20 },
                new SkillLevelCost { SkillLevel = 10, Cost = 40 },
                new SkillLevelCost { SkillLevel = 11, Cost = 80 },
            };

            var ranger = new CharacterClass("Waldläufer")
            {
                LevelingSchema = fighter,
                ResistanceBonuses = new Resistances { Physical = 2 },
                BaseSkills = new [] { "Balancieren","Geländelauf","Scharfschießen"},
                ExceptionalSkills = new [] { "Lesen von Zauberschrift","Rechnen","Verhören" },
                ForbiddenSkills = new[] {"Wissen von der Magie"}
            };

            var characterStat = new CharacterStat("Test1",1);
            var editableCharacterStat = new EditableCharacterStat("Test2",2);
            editableCharacterStat.Value = 3;

            Console.WriteLine(CalculateTotalCost(mage, shields));
            Console.WriteLine(CalculateTotalCost(mage, longsword, offensiveWeaponSkillLevels, 7));
            Console.WriteLine(CalculateTotalCost(fighter, dagger, offensiveWeaponSkillLevels, 10));
            //Console.WriteLine(CalculateTotalCost(fighter, longsword, offensiveWeaponSkillLevels, 15));
            Console.WriteLine(characterStat.Value);
            Console.WriteLine(editableCharacterStat.Value);
            Console.WriteLine(((CharacterStat)editableCharacterStat).Value);
            Console.ReadKey();

        }

        private static int CalculateTotalCost(LevelingSchema characterClass, WeaponCategory weaponCategory)
        {
            var totalCost = Math.Floor(characterClass.WeaponFactor * weaponCategory.Cost.Value);
            return (int)totalCost;
        }

        private static int CalculateTotalCost(LevelingSchema characterClass, Weapon weapon, List<SkillLevelCost> skillLevelCosts, byte targetSkillLevel)
        {
            SkillLevelCost targetSkillLevelCost;
            try
            {
                targetSkillLevelCost = skillLevelCosts.SingleOrDefault(x => x.SkillLevel == targetSkillLevel);
                if (targetSkillLevelCost.Equals(default(SkillLevelCost)))
                {
                    throw new ArgumentOutOfRangeException(nameof(skillLevelCosts), $" Skill level {targetSkillLevel} is not defined. Please slap the user.");
                }
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentOutOfRangeException(nameof(skillLevelCosts), $" Skill level {targetSkillLevel} is defined more than once. A unique value could not be determined. Please slap the developer.");
            }
            var totalCost = Math.Floor(characterClass.WeaponFactor * targetSkillLevelCost.Cost * weapon.Difficulty);
            return (int)totalCost;
        }
    }
}
