using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int powerEffect = 10;
        private const int aggressionEffect = 3;

        public Weapon()
            : base(0, 0, 0)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Weapon.powerEffect;
                this.AggressionEffect = Weapon.aggressionEffect;
            }
        }
    }
}
