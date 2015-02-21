using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerCatalyst : Catalist
    {
        private const int powerEffect = 3;
        private const int healthEffect = 0;
        private const int aggressionEffect = 0;
        
        public PowerCatalyst()
            : base(powerEffect: PowerCatalyst.powerEffect)
        {
        }
    }
}
