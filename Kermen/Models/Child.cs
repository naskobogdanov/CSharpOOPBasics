using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class Child
    {
        private decimal[] consimprions;

        public Child(decimal[] consimprions)
        {
            this.consimprions = consimprions;
        }

        public decimal GetTotalConsumption()
        {
            return this.consimprions.Sum();
        }
    }
}