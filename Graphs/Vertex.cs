using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Vertex : IEqualityComparer<Vertex>
    {
        public String Name {get; set;} 
        public List<Edge> _connectedEdges = new List<Edge>();

        public Vertex(String name) 
        {
            Name = name;
        }

        public List<Edge> GetConnectedEdges()
        {
            return _connectedEdges;
        }

        public IEnumerable<Edge> GetConnectedEdges(Vertex v)
        {
            return _connectedEdges.Where(_x => _x.HasVertex(v)) ;
        }

        public void RemoveSelfLoop()
        {
            var _connEdges = new List<Edge>();
            foreach (var _ed in _connectedEdges) {
                if (!_ed.IsSelfLoop())
                    _connEdges.Add(_ed);
            }
            _connectedEdges = _connEdges;
        }

        public Edge Connect(Vertex v)
        {
            var _e = new Edge(this, v);
            _connectedEdges.Add(_e);

            return _e;
        }

        # region Equality
        // override equals
        public override bool Equals(object obj)
        {
            var _v1 = obj as Vertex;
            if (_v1 != null)
                return this.Name.Equals(_v1.Name);

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public bool Equals(Vertex x, Vertex y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Vertex obj)
        {
            return obj.GetHashCode();
        }
        # endregion
    }
}
