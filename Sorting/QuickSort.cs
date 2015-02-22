using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSort
    {
        public void Sort(ref int[] A, int lo, int hi)
        {
            if (lo < hi)
            {
                var p = Partition(ref A, lo, hi);
                Sort(ref A, lo, p-1);
                Sort(ref A, p+1, hi);
            }
        }

        public void SortWithCount(ref int[] A, int lo, int hi, ref long count)
        {
            if (lo < hi)
            {
                // default - first element is pivot 

                // if last element is pivot - do a swap here
                var _t = A[lo]; A[lo] = A[hi]; A[hi] = _t;

                // median 3 rule


                var p = Partition(ref A, lo, hi);
                //count += lo + p - 1;
                SortWithCount(ref A, lo, p - 1, ref count);
                //count += p + hi + 1;
                SortWithCount(ref A, p + 1, hi, ref count);

                count += (lo + hi -1);
            }
        }

        // in-place partition
        public int Partition(ref int[] A, int l, int r)
        {
            var _pivot = A[l];
            var _i = l + 1;

            for (var _j = l + 1; _j <= r; _j++)
            {
                if (A[_j] < _pivot)
                {
                    // swap
                    var _t = A[_j]; A[_j] = A[_i]; A[_i] = _t;
                    _i++;
                }
            }

            // put the pivot in correct place
            var _tt = A[_i-1]; A[_i-1] = A[l]; A[l] = _tt;

            // return location of the pivot
            return _i - 1;
        }
    }
}
