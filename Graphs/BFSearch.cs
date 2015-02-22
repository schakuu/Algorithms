using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class BFSearch
    {
        public void DoBreadthFirstSearch(UndirectedGraph g, Vertex s)
        {
            var _explored = new List<Vertex>();
            var _queue = new Queue<Vertex>();

            Console.WriteLine("Found vertex: [{0}]", s.Name);
            _explored.Add(s);
            _queue.Enqueue(s);

            while (_queue.Count > 0)
            {
                var _v = _queue.Dequeue();
                foreach (var _e in _v._connectedEdges)
                {
                    if (_e.U.Equals(_v))
                    {
                        if (!_explored.Contains(_e.V))
                        {
                            _explored.Add(_e.V);
                            _queue.Enqueue(_e.V);
                            Console.WriteLine("Found vertex: [{0}]", _e.V.Name);
                        }
                    }
                    else
                    {
                        if (_e.V.Equals(_v))
                        {
                            if (!_explored.Contains(_e.U))
                            {
                                _explored.Add(_e.U);
                                _queue.Enqueue(_e.U);
                                Console.WriteLine("Found vertex: [{0}]", _e.U.Name);
                            }
                        }
                    }
                }
            }
        }

        public void DoBreadthFirstSearchWithDistance(UndirectedGraph g, Vertex s)
        {
            var _explored = new List<Vertex>();
            var _queue = new Queue<Tuple<Vertex, int>>();

            _explored.Add(s);
            _queue.Enqueue(Tuple.Create(s, 0));
            Console.WriteLine("Found vertex: [{0}] Layer [0]", s.Name);

            while (_queue.Count > 0)
            {
                var _v = _queue.Dequeue();
                foreach (var _e in _v.Item1._connectedEdges)
                {
                    Tuple<Vertex, int> _t = null;
                    if (_e.U.Equals(_v.Item1))
                    {
                        if (!_explored.Contains(_e.V))
                        {
                            _explored.Add(_e.V);
                            _t = Tuple.Create(_e.V, _v.Item2 + 1);
                            _queue.Enqueue(_t);
                            Console.WriteLine("Found vertex: [{0}] Layer [{1}]", _t.Item1.Name, _t.Item2);
                        }
                    }
                    else
                    {
                        if (_e.V.Equals(_v.Item1))
                        {
                            if (!_explored.Contains(_e.U))
                            {
                                _explored.Add(_e.U);
                                _t = Tuple.Create(_e.U, _v.Item2 + 1);
                                _queue.Enqueue(_t);
                                Console.WriteLine("Found vertex: [{0}] Layer [{1}]", _t.Item1.Name, _t.Item2);
                            }
                        }
                    }
                }
            }
        }

    }
}
