using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int powerEffect = -1;
        private const int healthEffect = 0;
        private const int aggressionEffect = 20;

        public InfestationSpores()
            : base(InfestationSpores.powerEffect, InfestationSpores.healthEffect, InfestationSpores.aggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
