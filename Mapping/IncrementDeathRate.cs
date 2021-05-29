using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class IncrementDeathRate :IMapper
    {
        private double rate;
        public IncrementDeathRate(double rate)
        {
            this.rate = rate;
        }

        public VirusData MapData(VirusData vd)
        {
            return new VirusData(vd.VirusName, vd.DeathRate + rate, vd.InfectionRate, vd.Genomes);
        }
    }
}
