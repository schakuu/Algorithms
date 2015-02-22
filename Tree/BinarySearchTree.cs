using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinarySearchTree
    {
        Node RootNode;

        public BinarySearchTree() { }
        public BinarySearchTree(IEnumerable<int> values)
            : this()
        {
            foreach (var _i in values)
                Insert(_i);
        }

        public void Insert(int value)
        {
            if (RootNode == null)
                RootNode = new Node { Value = value };
            else
            {
                RootNode.Insert(value);
            }
        }

        public bool Contains(int i)
        {
            if (RootNode != null)
                return RootNode.Contains(i);

            return false;
        }

        public IEnumerable<int> Traverse()
        {
            return RootNode.Traverse();
        }
    }
}
