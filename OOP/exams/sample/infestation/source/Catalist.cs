using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Catalist : Supplement
    {
        public Catalist(int powerEffect = 0, int healthEffect = 0, int aggressionEffect = 0)
            : base(powerEffect: powerEffect, healthEffect: healthEffect, aggressionEffect: aggressionEffect)
        {
        }
    }
}
