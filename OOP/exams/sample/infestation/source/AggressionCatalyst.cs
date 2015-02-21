using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AggressionCatalyst : Catalist
    {
        private const int powerEffect = 0;
        private const int healthEffect = 0;
        private const int aggressionEffect = 3;

        public AggressionCatalyst()
            : base(aggressionEffect: AggressionCatalyst.aggressionEffect)
        {
        }
    }
}
