using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class FilterIterator : IIterator
    {
        private IIterator iterator;
        private IFilter filter;
        private VirusData next;
        public FilterIterator(IIterator iterator, IFilter filter)
        {
            this.iterator = iterator;
            this.filter = filter;
            this.next = null;
        }
        public bool HasNext()
        {
            bool hasNext = true;
            bool found = false;
            while (hasNext && !found)
            {
                hasNext = iterator.HasNext();
                if (hasNext)
                {
                    next = iterator.Next();
                    found = filter.FilterCondition(next);
                }
            }

            return hasNext;
        }

        public VirusData Next()
        {
            return next;
        }
    }
}
