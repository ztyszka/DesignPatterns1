using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class ConcatenatedIterator : IIterator
    {
        private IIterator iter1;
        private IIterator iter2;
        private bool usedSecondIterator;

        public ConcatenatedIterator(IIterator iter1, IIterator iter2)
        {
            this.iter1 = iter1;
            this.iter2 = iter2;
            this.usedSecondIterator = false;
        }

        public bool HasNext()
        {
            if (iter1.HasNext())
                return iter1.HasNext();
            usedSecondIterator = true;
            return iter2.HasNext();
        }

        public VirusData Next()
        {
            if (!usedSecondIterator)
                return iter1.Next();
            return iter2.Next();
        }
    }
}
