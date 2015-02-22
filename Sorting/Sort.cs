using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Sort
    {
        public int[] MergeSort(int[] input)
        {
            return _MergeSort(input);
        }

        private int[] _MergeSort(int[] input)
        {
            if (input.Length == 1) return input;

            var _splitLocation = (int)(input.Length / 2.0);
            return _Merge(_MergeSort(input.Take(_splitLocation).ToArray()), _MergeSort(input.Skip(_splitLocation).ToArray()));
        }

        private int[] _Merge(int[] A, int[] B)
        {
            var C = new int[A.Length + B.Length];

            int i = 0, j = 0, k = 0;

            for (; k < C.Length; k++)
            {
                if (i >= A.Length)
                {
                    C[k] = B[j];
                    j++;
                }
                else
                {
                    if (j >= B.Length)
                    {
                        C[k] = A[i];
                        i++;
                    }
                    else
                    {
                        if (A[i] <= B[j])
                        {
                            C[k] = A[i];
                            i++;
                        }
                        else
                        {
                            C[k] = B[j];
                            j++;
                        }
                    }
                }
            }

            return C;
        }

        public int[] MergeSortAndCountInversions(int[] input, ref long numInversions)
        {
            return _MergeSortAndCountInversions(input, ref numInversions);
        }

        private int[] _MergeSortAndCountInversions(int[] input, ref long numInversions) 
        {
            if (input.Length == 1) return input;

            var _splitLocation = (int)(input.Length / 2);
            return _MergeAndCountInversions(_MergeSortAndCountInversions(input.Take(_splitLocation).ToArray(), ref numInversions), _MergeSortAndCountInversions(input.Skip(_splitLocation).ToArray(), ref numInversions), ref numInversions);
        }

        private int[] _MergeAndCountInversions(int[] A, int[] B, ref long numInversions)
        {
            // assumption here is both A and B are sorted
            var C = new int[A.Length + B.Length];

            int i = 0, j = 0, k = 0;

            for (; k < C.Length; k++)
            {
                if (i >= A.Length)
                {
                    C[k] = B[j];
                    j++;
                }
                else
                {
                    if (j >= B.Length)
                    {
                        C[k] = A[i];
                        i++;
                    }
                    else
                    {
                        if (A[i] <= B[j])
                        {
                            C[k] = A[i];
                            i++;
                        }
                        else
                        {
                            
                            C[k] = B[j];
                            j++;

                            // this represents an inversion condition
                            // number of inversions is 
                            numInversions += (A.Length - i);
                        }
                    }
                }
            }

            return C;
        }
    }
}
