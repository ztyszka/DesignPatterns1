using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    interface IDatabaseIterator
    {
        public bool HasNext();
        public SimpleDatabaseRow Next();
    }
}
