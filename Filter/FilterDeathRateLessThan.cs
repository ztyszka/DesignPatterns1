using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class FilterDeathRateLessThan : IFilter
    {
        private readonly double condition;
        public FilterDeathRateLessThan(double condition)
        {
            this.condition = condition;
        }
        public bool FilterCondition(VirusData vd)
        {
            if (vd.DeathRate < condition)
                return true;
            return false;
        }
    }
}
