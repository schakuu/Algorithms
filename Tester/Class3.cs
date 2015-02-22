using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sorting;
namespace Tester
{
    class Class3
    {
        public static void Main1(string[] args)
        {
            int[] A = new int[] { 3, 8, 2, 5, 1, 4, 7, 6 };

            new QuickSort().Sort(ref A, 0, A.Length - 1);
            Console.WriteLine("[{0}]", string.Join(",", A));

            int[] B = File.ReadAllLines("QuickSort.txt").Select(_x => int.Parse(_x)).ToArray();
            long count = 0;
            new QuickSort().SortWithCount(ref B, 0, B.Length - 1, ref count);
            Console.WriteLine("[{0}]", string.Join(",", B));
            Console.WriteLine("Num Comparisons [{0}]", count);
        }
    }
}
