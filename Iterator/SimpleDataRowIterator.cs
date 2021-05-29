using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class SimpleDataRowIterator : IIterator
    {
        private readonly IDatabaseIterator iterator;
        private IGenome genome;
        public SimpleDataRowIterator(IDatabaseIterator databaseIterator, IGenome genome)
        {
            this.iterator = databaseIterator;
            this.genome = genome;
        }
        public bool HasNext()
        {
            return this.iterator.HasNext();
        }

        public VirusData Next()
        {
            SimpleDatabaseRow dr = iterator.Next();
            VirusData vd = new VirusData(dr.VirusName, dr.DeathRate, dr.InfectionRate, genome.FindID(dr.GenomeId));
            return vd;
        }
    }
}
