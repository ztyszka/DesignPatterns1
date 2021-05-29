using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class OvercomplicatedDatabaseIterator
    {
        private Stack<INode> nodes;
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase database)
        {
            nodes = new Stack<INode>();
            this.nodes.Push(database.Root);
        }

        public bool HasNext()
        {
            if (nodes.Count > 0)
                return true;
            return false;
        }

        public INode Next()
        {
            INode n = nodes.Pop();
            foreach (var node in n.Children)
                nodes.Push(node);
            return n;
        }
    }
}
