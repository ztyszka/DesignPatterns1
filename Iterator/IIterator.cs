using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    interface IIterator
    {
        public bool HasNext();
        public VirusData Next();
    }
}

