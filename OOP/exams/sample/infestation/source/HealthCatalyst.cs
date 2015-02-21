using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HealthCatalyst : Catalist
    {
        private const int powerEffect = 0;
        private const int healthEffect = 3;
        private const int aggressionEffect = 0;

        public HealthCatalyst()
            : base(healthEffect: HealthCatalyst.healthEffect)
        {
        }
    }
}
