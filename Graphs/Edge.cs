using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Edge
    {
        public String Name { get { return string.Format("{0}_{1}", U.Name, V.Name); } }
        public Vertex U {get; set;}
        public Vertex V { get; set; }

        public Edge(Vertex u, Vertex v)
        {
            U = u;
            V = v;
        }

        public bool IsSelfLoop() 
        {
            return U.Equals(V);
        }

        public bool HasVertex(Vertex v)
        {
            return v.Equals(V) || v.Equals(U);
        }

        public Vertex Contract(Vertex _toRemove, Vertex _toInsert)
        {
            if (U.Equals(_toRemove))
            {
                U = _toInsert;
                U.Connect(V);
            }
            else
            {
                if (V.Equals(_toRemove))
                {
                    V = _toInsert;
                    V.Connect(U);
                }
            }

            return null;
        }
    }
}
