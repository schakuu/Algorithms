using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DFSearch
    {
        List<Vertex> _explored = new List<Vertex>();

        public void DoDepthFirstSearch(UndirectedGraph g, Vertex s)
        {
            Console.WriteLine("Found vertex: [{0}]", s.Name);
            _explored.Add(s);

            foreach (var _e in s._connectedEdges)
            {
                if (_e.U.Equals(s))
                {
                    if (!_explored.Contains(_e.V))
                    {
                        _explored.Add(_e.V);
                        DoDepthFirstSearch(g, _e.V);
                    }
                }
                else
                {
                    if (_e.V.Equals(s))
                    {
                        if (!_explored.Contains(_e.U))
                        {
                            _explored.Add(_e.U);
                            DoDepthFirstSearch(g, _e.U);
                        }
                    }
                }
            }
        }
    }
}
