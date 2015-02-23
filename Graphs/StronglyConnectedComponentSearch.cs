using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class StronglyConnectedComponentSearch
    {

        bool[] _reverse_loop_explored;
        int[] _f;
        int _t;

        public StronglyConnectedComponentSearch(int n)
        {
            _reverse_loop_explored = Enumerable.Repeat(false, n+1).ToArray();
            _f = new int[n];
        }

        public void SCCSearch(DirectedGraph g, int n)
        {
            _t = 0;
            // DFS loop on reverse of g
            for (int _i = n; _i >= 1; _i--)
            {
                if (!_reverse_loop_explored[_i])
                    DoDepthFirstSearchRev(g, g.Vertices[_i]);
            }
        }

        public void DoDepthFirstSearchRev(DirectedGraph g, DirectedVertex s)
        {
            _reverse_loop_explored[s.Name] = true;

            foreach (var _v in s.ReverseConnectedVertices)
            {
                if (!_reverse_loop_explored[_v.Name])
                    DoDepthFirstSearchRev(g, _v);
            }

            _f[++_t] = s.Name;
        }

    }
}
