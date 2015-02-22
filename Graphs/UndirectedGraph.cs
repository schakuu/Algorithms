using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class UndirectedGraph
    {
        IList<Edge> _edges = new List<Edge>();
        IList<Vertex> _vertices = new List<Vertex>();

        public UndirectedGraph()
        {
        }

        # region Creation
        public Vertex AddVertex(string name)
        {
            var _vtx = _vertices.SingleOrDefault(_v => _v.Name.Equals(name));
            if (_vtx == null)
            {
                _vtx = new Vertex(name);
                _vertices.Add(_vtx);
            }

            return _vtx;
        }

        public void AddEdge(Edge e)
        {
            _edges.Add(e);
        }

        public void AddLine(string line)
        {
            var _tokens = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            // create this vertex if it does not exist
            // if it does exist, get it from list of vertices
            var _thisVertex = _vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[0]));
            if (_thisVertex == null)
            {
                _thisVertex = new Vertex(_tokens[0]);
                _vertices.Add(_thisVertex);

                // if this main vertex did not exist, then none of the child edges can possibly exist, add all
                for (var _i = 1; _i < _tokens.Length; _i++)
                {
                    var _connectedToVertex = _vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[_i]));
                    if (_connectedToVertex == null)
                    {
                        _connectedToVertex = new Vertex(_tokens[_i]);
                        _vertices.Add(_connectedToVertex);
                    }
                    _edges.Add(new Edge(_thisVertex, _connectedToVertex));
                }
            }
            else
            {
                // if the main vertex did exist, the each edge needs to be checked for existence
                for (var _i = 1; _i < _tokens.Length; _i++)
                {
                    var _connectedToVertex = _vertices.SingleOrDefault(_x => _x.Name.Equals(_tokens[_i]));
                    if (_connectedToVertex == null)
                    {
                        _connectedToVertex = new Vertex(_tokens[_i]);
                        _vertices.Add(_connectedToVertex);
                    }

                    var _thisEdge = _edges.SingleOrDefault(_e => { return ((_e.U.Equals(_thisVertex) && _e.V.Equals(_connectedToVertex)) || (_e.V.Equals(_thisVertex) && _e.U.Equals(_connectedToVertex))); });
                    if (_thisEdge == null)
                        _edges.Add(new Edge(_thisVertex, _connectedToVertex));
                }
            }

        }

        # endregion

        # region Graph Min Cut
        public int FindMinCut()
        {
            if (_vertices.Count > 2)
            {
                while (_vertices.Count() > 2)
                {
                    // select an edge at random
                    var _randEdge = _edges[new Random().Next(0, _edges.Count - 1)];

                    // contract the edge
                    var _u = _randEdge.U; var _v = _randEdge.V;
                    // remove V
                    // find all edges connected to _v, for each of those edges, change that vertex to _u, update vertex connection list
                    var _connEdges = new List<Edge>(_v.GetConnectedEdges());
                    _connEdges.ForEach(_e =>
                        {
                            _e.Contract(_v, _u);
                        });

                    // remove self loops
                    _u.RemoveSelfLoop();

                    // remove this edge
                    _vertices.Remove(_v);
                    _edges.Remove(_randEdge);
                }
            }

            if (_vertices.Count() == 2)
            {
                var _e = FindEdges(_vertices.First(), _vertices.Last());
                return _e.Count();
            }

            return 0;
        }
        # endregion

        # region Find
        public IEnumerable<Edge> FindEdges(Vertex u)
        {
            return u.GetConnectedEdges();
        }

        public IEnumerable<Edge> FindEdges(Vertex u, Vertex v)
        {
            return u.GetConnectedEdges(v);
        }
        # endregion
    }
}
