using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graphs;

namespace Tester
{
    public class Class4
    {
        public static void Main(string[] args)
        {
            //var _g1 = new UndirectedGraph();
            //_g1.AddLine("1  2   3");
            //_g1.AddLine("2  1   3   4");
            //_g1.AddLine("3  1   2   4");
            //_g1.AddLine("4  2   3");
            //Console.WriteLine("Min Cut [{0}]", _g1.FindMinCut());

            //var _g2 = new UndirectedGraph2();
            //_g2.AddLine("1  2   3");
            //_g2.AddLine("2  1   3   4");
            //_g2.AddLine("3  1   2   4");
            //_g2.AddLine("4  2   3");
            //Console.WriteLine("Min Cut [{0}]", _g2.FindMinCut());

            //var _g3 = new UndirectedGraph2();
            //_g3.AddLine("1 2 3 4");
            //_g3.AddLine("2 1 3 4 5");
            //_g3.AddLine("3 1 2 4");
            //_g3.AddLine("4 3 1 2 7");
            //_g3.AddLine("5 2 6 8 7");
            //_g3.AddLine("6 5 7 8");
            //_g3.AddLine("7 4 5 6 8");
            //_g3.AddLine("8 7 5 6");
            //Console.WriteLine("Min Cut [{0}]", _g3.FindMinCut());

            var _g4 = new UndirectedGraph2();
            var _lines = File.ReadAllLines("kargerMinCut.txt");
            foreach (var _l in _lines)
                _g4.AddLine(_l);

            Console.WriteLine("Min Cut [{0}]", _g4.FindMinCut());

        }
    }
}
