using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Fibonacci;
using MathLib;
using Searching;
using Sorting;
using Tree;

namespace Tester
{
    class Program
    {

        public static void Main11(string[] args)
        {
            var _in = decimal.Parse(args[0]);
            var _out = new Powers().Sqrt(_in);

            Console.Write("Sqrt [{0}] is [{1}]", _in, _out);
        }

        public static void Main10(string[] args)
        {
            var inputArray = args.Select(_x => int.Parse(_x)).ToArray();

            Console.Write("Max [{0}]", new SimpleSearch().SearchMaxDC(inputArray));
        }

        public static void Main9(string[] args)
        {
            //var _words = new string[] { "A", "to", "tea", "ted", "ten", "ton", "i", "in", "inn"};
            var _trie = new Trie();
            var _dictWords = File.ReadLines("words.txt");

            foreach (var _d in _dictWords)
                _trie.Insert(_d);

            //Console.WriteLine("Found for searchstring t [{0}]", string.Join(",", _trie.FindByHint("t")));
            //Console.WriteLine("Found for searchstring te [{0}]", string.Join(",", _trie.FindByHint("te")));

            var _hint = string.Empty;
            while (!_hint.Equals("exit"))
            {
                var _words = _trie.FindByHint(_hint);
                Console.WriteLine("Found [{0}] matches for searchstring [{1}]", _words.Length, _hint);
                Console.WriteLine("Matches [{0}]", string.Join(",", _words));
                _hint = Console.ReadLine();
            }

        }

        public static void Main8(string[] args)
        {
            int _len0 = int.Parse(args[0]);
            int _len1 = int.Parse(args[1]);

            var _array0 = new int[_len0];
            var _array1 = new int[_len1];
            var _r = new Random();

            for (int _i = 0; _i < _len0; _i++)
                _array0[_i] = _r.Next(0, 100);
            for (int _i = 0; _i < _len1; _i++)
                _array1[_i] = _r.Next(0, 100);


            Console.WriteLine("Array0: [{0}]", string.Join(",", _array0));
            Console.WriteLine("Array1: [{0}]", string.Join(",", _array1));

            // insert the larger array into a BST, so that we can take advantage of logn searching in the larger array
            BinarySearchTree _bst;
            List<int> _l = new List<int>();

            if (_array0.Length < _array1.Length)
            {
                _bst = new BinarySearchTree(_array1);
                Console.WriteLine("Sorted 1: [{0}]", string.Join(",", _bst.Traverse()));

                Array.ForEach(_array0, _x => { if (_bst.Contains(_x)) _l.Add(_x); });
            }
            else
            {
                _bst = new BinarySearchTree(_array0);
                Console.WriteLine("Sorted 0: [{0}]", string.Join(",", _bst.Traverse()));

                Array.ForEach(_array1, _x => { if (_bst.Contains(_x)) _l.Add(_x); });
            }

            Console.WriteLine("Intersection: [{0}]", string.Join(",", _l));

        }

            public static void Main7(string[] args)
            {
                //Stack<int> _s = new Stack<int>(args.Select(x=> int.Parse(x)));
                Stack<int> _s = new Stack<int>(File.ReadAllLines("IntegerArray.txt").Select(_x => int.Parse(_x)));

                Console.WriteLine(" stack length [{0}]", _s.Count);

                PopAndMerge(ref _s);

                Console.WriteLine("[{0}]", string.Join(",", _s));
            }

            static void stackSortDesc(ref Stack<int> s)
            {
                // do nothing if count is 1
                if (s.Count == 1 || s.Count == 0) return;

                // 

                var _t1 = s.Pop();
                var _t2 = s.Pop();

                stackSortDesc(ref s);
                if (_t1 < _t2)
                {
                    s.Push(_t1);
                    s.Push(_t2);

                }
                else
                {
                    s.Push(_t2);
                    s.Push(_t1);
                }
            }

            static void PopAndMerge(ref Stack<int> stack)
            {
                if (stack.Count == 0 || stack.Count == 1) return;

                var _t = stack.Pop();
                PopAndMerge(ref stack);
                Merge(ref stack, _t);                
            }

            static void Merge(ref Stack<int> stack, int v)
            {
                // assume stack is fully sorted, simply insert the value v in the correct place
                if (stack.Count == 0)
                    stack.Push(v);
                else
                {
                    var _t = stack.Pop();

                    if (_t < v)
                    {
                        // v is larger than the largest value in sorted stack
                        stack.Push(_t);
                        stack.Push(v);
                    }
                    else
                    {
                        Merge(ref stack, v);
                        stack.Push(_t);
                    }
                }
            }
        
        public static void Main6(string[] args)
        {
            var _prices = args.Select(x => int.Parse(x)).ToArray();

            
            var _decision = new Util().Decide(_prices);
            Console.WriteLine("[{0}]", string.Join(",", _decision));
            
        }

        static void Main5(string[] args)
        {
            var _bst = new BinarySearchTree();
            var A = args.Select(x => int.Parse(x));

            foreach (var _a in A)
                _bst.Insert(_a);
        }

        static void Main4(string[] args)
        {
            var _i = int.Parse(args[0]);
            Console.WriteLine("Input {0}, Reverse {1}", _i, new Util().Reverse(_i));
        }

        static void Main3(string[] args)
        {
            var _start = new Stopwatch();
            var i = int.Parse(args[0]);

            LargeInt[] series;

            _start.Start();
            var _fibn = new Fibonacci.Fibonacci().Fib3(i, out series);
            _start.Stop();

            Console.WriteLine("Fib1({0}) = {1}, in [{2}] ticks)", i, _fibn, _start.ElapsedTicks);
            Console.Write("series = [");
            foreach (var _s in series)
                Console.Write("{0},", _s.ToString());
            Console.WriteLine("]");

        }

        static void Main2(string[] args)
        {
            //var A = args.Select(x => int.Parse(x)).ToArray();
            var A = File.ReadAllLines("IntegerArray.txt").Select(_x => int.Parse(_x)).ToArray();
            long numInversions = 0;

            var _start = new Stopwatch();
            _start.Start();
            //var B = new Sort().MergeSort(A);
            var B = new Sort().MergeSortAndCountInversions(A, ref numInversions);
            _start.Stop();

            Console.WriteLine("Mergesort for {0} elements took {1} ticks, with [{2}] inversions", A.Length, _start.ElapsedTicks, numInversions);
            //Console.WriteLine("Output [{0}]", string.Join(",", B));
            
        }

        static void Main1(string[] args)
        {
            var _start = new Stopwatch();
            var i = int.Parse(args[0]);

            long[] series;

            _start.Start();
            var _fibn = new Fibonacci.Fibonacci().Fib2(i, out series);
            _start.Stop();

            Console.WriteLine("Fib1({0}) = {1}, in [{2}] ticks)", i, _fibn,  _start.ElapsedTicks);
            Console.WriteLine("series = [{0}]",  string.Join(",", series));

        }
    }

    class Util
    {
        public string[] Decide(int[] prices)
        {
            int _currentlyOwned = 0;
            var _decision = new string[prices.Length];

            for (var _i = 0; _i < prices.Length - 1; _i++)
            {
                // if you dont have any stock, you can only make buy decision
                if (_currentlyOwned == 0)
                {
                    // only buy if next px is higher
                    if (prices[_i] < prices[_i + 1])
                    {
                        _decision[_i] = "b";
                        _currentlyOwned = 1;
                    }
                    else
                        _decision[_i] = "h";
                }
                else // if you currently hold stock, you can only make sell or hold decision
                {
                    if (prices[_i] > prices[_i + 1])
                    {
                        _decision[_i] = "s";
                        _currentlyOwned = 0;
                    }
                    else
                    {
                        _decision[_i] = "h";
                    }
                }
            }

            return _decision;
        }

        public string Reverse(int i)
        {
            var _r = i % 10;
            var _i = i / 10;

            if (_i == 0)
                return _r.ToString();
            else
                return _r.ToString() + Reverse(_i);
        }
    }
}
