using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graphs;

namespace Tester
{
    public class Class5
    {
        public static void Main(string[] args)
        {
            var _n = 875714;
            var _grev = new DG(_n);
            var _lines = File.ReadAllLines("SCC.txt");

            var _tokenizer = new string[] {" ", "\t"};
            Array.ForEach(_lines, _l => 
            {
                var _tokens = _l.Split(_tokenizer, StringSplitOptions.RemoveEmptyEntries).Select(_x => int.Parse(_x)).ToArray();
                _grev.Add(_tokens[1], _tokens[0]);
            });

            var _f = new Search().DoSearch(_grev, _n);
        }

        public static void Main6(string[] args)
        {
            var _n = 875714;
            var _g = new DirectedGraph(_n);

            var _lines = File.ReadAllLines("SCC.txt");
            Array.ForEach(_lines, _l => { _g.AddLine1(_l); });

            var _sccSearch = new StronglyConnectedComponentSearch(_n);
            _sccSearch.SCCSearch(_g, _n);
        }

        public static void Main5(string[] args)
        {
            // graph search
            var _g1 = new UndirectedGraph();
            _g1.AddLine("1  2   3");
            _g1.AddLine("2  1   3   4");
            _g1.AddLine("3  1   2   4");
            _g1.AddLine("4  2   3");
            new BFSearch().DoBreadthFirstSearch(_g1, _g1._vertices[0]);
            new DFSearch().DoDepthFirstSearch(_g1, _g1._vertices[0]);
        }
    }

    class DG
    {
        public ArrayList[] _vertices;

        public DG(int n)
        {
            _vertices = Enumerable.Repeat(new ArrayList(), n + 1).ToArray();
        }

        public void Add(int tail, int head)
        {
            _vertices[tail].Add(head);
        }
    }

    class Search
    {
        int _t;
        int[] _f;
        bool[] _explored;

        public int[] DoSearch(DG g, int n)
        {
            _t = 0;
            _f = new int[n];
            _explored = Enumerable.Repeat(false, n+1).ToArray();

            for (int _i = n; _i >= 1; _i--)
            {
                if (!_explored[_i])
                {
                    DFSSearch(g, _i);
                }
            }

            return _f;
        }

        public void DFSSearch(DG g, int i)
        {
            _explored[i] = true;
            foreach (int j in g._vertices[i])
            {
                if (!_explored[j])
                    DFSSearch(g, j);
            }
            _f[i] = ++_t;
        }
    }

}
