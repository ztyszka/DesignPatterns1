using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class SimpleGenomeDatabaseAdapter : IGenome
    {
        private SimpleGenomeDatabase database;
        public SimpleGenomeDatabaseAdapter(SimpleGenomeDatabase database)
        {
            this.database = database;
        }
        public IReadOnlyList<GenomeData> FindID(Guid id)
        {
            List<GenomeData> genomes = new List<GenomeData>();
            foreach (var g in database.genomeDatas)
                if (g.Id == id)
                    genomes.Add(g);
            return genomes;
        }

        public IReadOnlyList<GenomeData> FindTag(string tag)
        {
            List<GenomeData> genomes = new List<GenomeData>();
            foreach (var g in database.genomeDatas)
                foreach (var t in g.Tags)
                    if (t == tag && !genomes.Contains(g))
                        genomes.Add(g);
            return genomes;
        }
    }
}
