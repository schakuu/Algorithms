using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node
    {
        public Node Parent { get; set; }
        public Node Left {get; set;}
        public Node Right {get; set;}

        public int? Value {get; set;}

        public void Insert(int value)
        {
            if (value < Value.Value)
            {
                if (Left == null)
                    Left = new Node { Value = value };
                else
                    Left.Insert(value);
            }
            if (value > Value.Value)
            {
                if (Right == null)
                    Right = new Node { Value = value };
                else
                    Right.Insert(value);
            }
        }
        public bool Contains(int value)
        {
            if (Value.Value.Equals(value))
                return true;
            else
            {
                if (Value.Value > value && Left != null)
                    return Left.Contains(value);
                if (Value.Value < value && Right != null)
                    return Right.Contains(value);
            }

            // if it reaches here, return false
            return false;
        }

        public IEnumerable<int> Traverse()
        {
            IEnumerable<int> left = (Left == null ? new int[0] : Left.Traverse());
            IEnumerable<int> right = (Right == null ? new int[0] : Right.Traverse());
                
            return left.Union(new int[] { Value.Value }).Union(right);
        }
    }
}
