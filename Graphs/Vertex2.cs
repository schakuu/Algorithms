using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Vertex2 : IEqualityComparer<Vertex2>
    {
        public int Name { get; set; }
        public List<Vertex2> ConnectedTo = new List<Vertex2>();

        public Vertex2(int name)
        {
            Name = name;
        }

        public void ConnectTo(Vertex2 v) {
            ConnectedTo.Add(v);
            v.ConnectedTo.Add(this);
        }

        public void DisconnectFrom(Vertex2 v)
        {
            ConnectedTo.Remove(v);
            v.ConnectedTo.Remove(this);
        }

        # region IEqualityComparer
        public bool Equals(Vertex2 x, Vertex2 y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Vertex2 obj)
        {
            return obj.Name.GetHashCode();
        }
        # endregion
    }
}
