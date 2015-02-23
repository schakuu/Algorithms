using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DirectedEdge
    {
        public String Name { get { return string.Format("{0}_>{1}", StartVertex.Name, EndVertex.Name); } }
        public DirectedVertex StartVertex { get; set; }
        public DirectedVertex EndVertex { get; set; }

        public DirectedEdge(DirectedVertex u, DirectedVertex v)
        {
            StartVertex = u;
            EndVertex = v;
        }
    }
}
