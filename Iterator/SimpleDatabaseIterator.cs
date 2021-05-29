using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class SimpleDatabaseIterator : IDatabaseIterator
    {
        private SimpleDatabase database;
        private int i;
        public SimpleDatabaseIterator(SimpleDatabase d)
        {
            this.database = d;
            this.i = 0;
        }
        public bool HasNext()
        {
            if (i < this.database.Rows.Count)
                return true;
            return false;
        }

        public SimpleDatabaseRow Next()
        {
            SimpleDatabaseRow vd = database.Rows[i];
            i++;
            return vd;
        }
    }
}
