using MidgardLevelHelperCore.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardLevelHelperCore
{
    [DebuggerDisplay("{Name} {Cost}")]
    public class WeaponCategory
    {
        public string Name { get; init; }
        public TotalExperiencePoints Cost { get; init; }
    }
}
