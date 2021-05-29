using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class OvercomplicatedIterator : IIterator
    {
        private OvercomplicatedDatabaseIterator iterator;
        private IGenome genome;
        public OvercomplicatedIterator(OvercomplicatedDatabaseIterator iterator, IGenome genome)
        {
            this.iterator = iterator;
            this.genome = genome;
        }
        public bool HasNext()
        {
            return iterator.HasNext();
        }

        public VirusData Next()
        {
            INode node = iterator.Next();
            
            return new VirusData(node.VirusName, node.DeathRate, node.InfectionRate, genome.FindTag(node.GenomeTag));
        }
    }
}
