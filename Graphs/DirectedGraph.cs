using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DirectedGraph
    {
        //public IList<DirectedEdge> Edges = new List<DirectedEdge>();
        //public IList<DirectedVertex> Vertices = new List<DirectedVertex>();
        public DirectedVertex[] Vertices;

        public DirectedGraph()
        {
        }

        public DirectedGraph(int n)
        {
            Vertices = new DirectedVertex[n+1];
            for (int i = 1; i <= n; i++)
            {
                Vertices[i] = new DirectedVertex(i);
            }
        }

        //public void AddLine(string line)
        //{
        //    var _tokens = line.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(_x => int.Parse(_x)).ToArray();

        //    // create this vertex if it does not exist
        //    // if it does exist, get it from list of vertices
        //    var _tailVertex = Vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[0]));
        //    if (_tailVertex == null)  { _tailVertex = new DirectedVertex(_tokens[0]); Vertices.Add(_tailVertex); }
        //    var _headVertex = Vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[1]));
        //    if (_headVertex == null)  { _headVertex = new DirectedVertex(_tokens[1]); Vertices.Add(_headVertex); }

        //    _tailVertex.Connect(_headVertex);
        //    _headVertex.ReverseConnect(_tailVertex);
        //    //Edges.Add(_tailVertex.Connect(_headVertex));
        //}

        public void AddLine1(string line)
        {
            var _tokens = line.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(_x => int.Parse(_x)).ToArray();

            Vertices[_tokens[0]].Connect(Vertices[_tokens[1]]);
            Vertices[_tokens[1]].ReverseConnect(Vertices[_tokens[0]]);
        }
    }
}
