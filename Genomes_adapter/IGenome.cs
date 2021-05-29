using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    interface IGenome
    {
        public IReadOnlyList<GenomeData> FindID(Guid id);
        public IReadOnlyList<GenomeData> FindTag(string tag);
    }
}
