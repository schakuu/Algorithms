using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public class Class1
    {
        public static void Main1(string[] args)
        {
            var _input = new int[] { 2, 5, 3, 7, 5, 8, 9, 1, 3 };

            var _qws = new QueueWithStack() ;

            Array.ForEach(_input, _x => _qws.Enqueue(_x));
            Console.WriteLine(_qws.Dequeue());
            Console.WriteLine(_qws.Dequeue());
            Console.WriteLine(_qws.Dequeue());

        }
    }

    public class QueueWithStack
    {
        private Stack<int> _s = new Stack<int>();

        public void Enqueue(int value) 
        {
            // push it to the end of the stack
            if (_s.Count() == 0)
                _s.Push(value);
            else
            {
                var _t = _s.Pop();
                Enqueue(value);
                _s.Push(_t);
            }

        }

        public int Dequeue() 
        {
            return _s.Pop();
        }

    }
}
