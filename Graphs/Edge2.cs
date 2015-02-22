using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Edge2
    {
        public Vertex2 U { get; set; }
        public Vertex2 V { get; set; }

        public Edge2(Vertex2 u, Vertex2 v)
        {
            U = u;
            V = v;

            U.ConnectTo(V);
            V.ConnectTo(U);
        }
    }
}
