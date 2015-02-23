using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DirectedVertex
    {
        public int Name {get; set;} 
        //public List<DirectedEdge> ConnectedEdges {get; set;}
        //public List<DirectedVertex> ReverseConnectedEdges { get; set; }

        public List<DirectedVertex> ConnectedVertices { get; set; }
        public List<DirectedVertex> ReverseConnectedVertices { get; set; }

        public DirectedVertex(int name) 
        {
            //ConnectedEdges = new List<DirectedEdge>();
            //ReverseConnectedEdges = new List<DirectedVertex>();
            ConnectedVertices = new List<DirectedVertex>();
            ReverseConnectedVertices = new List<DirectedVertex>();
            Name = name;
        }

        //public DirectedEdge Connect(DirectedVertex head)
        //{
        //    var _e = new DirectedEdge(this, head);
        //    //ConnectedEdges.Add(_e);

        //    return _e;
        //}

        public void Connect(DirectedVertex head)
        {
            ConnectedVertices.Add(head);
        }

        public void ReverseConnect(DirectedVertex head)
        {
            ReverseConnectedVertices.Add(head);
        }
    }
}
