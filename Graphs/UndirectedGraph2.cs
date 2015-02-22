using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class UndirectedGraph2
    {
        List<Vertex2> Vertices = new List<Vertex2>();
        List<Edge2> Edges = new List<Edge2>();

        public void AddLine(string line)
        {
            var _tokens = line.Split(new string[]{" ", "\t"}, StringSplitOptions.RemoveEmptyEntries).Select(_x => int.Parse(_x)).ToArray();
            
            // create this vertex if it does not exist
            // if it does exist, get it from list of vertices
            var _thisVertex = Vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[0]));
            if (_thisVertex == null)
            {
                _thisVertex = new Vertex2(_tokens[0]);
                Vertices.Add(_thisVertex);

                // if this main vertex did not exist, then none of the child edges can possibly exist, add all
                for (var _i = 1; _i < _tokens.Length; _i++)
                {
                    var _connectedToVertex = Vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[_i]));
                    if (_connectedToVertex == null)
                    {
                        _connectedToVertex = new Vertex2(_tokens[_i]);
                        Vertices.Add(_connectedToVertex);
                    }
                    Edges.Add(new Edge2(_thisVertex, _connectedToVertex));
                }
            }
            else
            {
                // if the main vertex did exist, the each edge needs to be checked for existence
                for (var _i = 1; _i < _tokens.Length; _i++)
                {
                    var _connectedToVertex = Vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[_i]));
                    if (_connectedToVertex == null)
                    {
                        _connectedToVertex = new Vertex2(_tokens[_i]);
                        Vertices.Add(_connectedToVertex);
                    }

                    var _thisEdge = Edges.SingleOrDefault(_e => { return ((_e.U.Equals(_thisVertex) && _e.V.Equals(_connectedToVertex)) || (_e.V.Equals(_thisVertex) && _e.U.Equals(_connectedToVertex))); });
                    if (_thisEdge == null)
                        Edges.Add(new Edge2(_thisVertex, _connectedToVertex));
                }

            }

        }

        public int FindMinCut()
        {
            if (Vertices.Count > 2)
            {
                while (Vertices.Count > 2)
                {
                    // select an edge at random
                    var _randEdge = Edges[new Random().Next(0, Edges.Count - 1)];
                    var _u = _randEdge.U; var _v = _randEdge.V;

                    // remove V
                    // find all edges connected to _v, for each of those edges, change that vertex to _u, update vertex connection list
                    var _connEdges = new List<Vertex2>(_v.ConnectedTo);
                    
                    // disconnect
                    _u.ConnectedTo.Remove(_v);
                    
                    //_connEdges.ForEach(_x => _v.DisconnectFrom(_x));
                    _connEdges.ForEach(_x => _u.ConnectTo(_x));

                    // remove self loop


                    // remove this vertex
                    Vertices.Remove(_v);

                    // remove this edge
                    Edges.Remove(_randEdge);
                }
            }

            if (Vertices.Count() == 2)
            {
                var _e = Vertices[0].ConnectedTo.Where(_x => _x.Equals(Vertices[1]));
                return _e.Count();
            }

            return 0;
        }
    }
}
