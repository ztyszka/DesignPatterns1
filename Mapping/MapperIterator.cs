using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class MapperIterator : IIterator
    {
        private IMapper mapper;
        private IIterator iterator;

        public MapperIterator(IIterator iterator, IMapper mapper)
        {
            this.mapper = mapper;
            this.iterator = iterator;
        }

        public bool HasNext()
        {
            return iterator.HasNext();
        }

        public VirusData Next()
        {
            return mapper.MapData(iterator.Next());
        }
    }
}
