using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class SimpleSearch
    {
        // use divide and conquor to find max in a unimodal array
        public int SearchMaxDC(int[] input)
        {
            if (input.Length == 1) return input[0];

            if (input.Length == 2) return (input[0] > input[1] ? input[0] : input[1]);

            int _splitLoc = (int)(input.Length / 2);
            if (input[_splitLoc] > input[_splitLoc + 1])
                return SearchMaxDC(input.Take(_splitLoc+1).ToArray());
            else
                return SearchMaxDC(input.Skip(_splitLoc+1).ToArray());
        }
    }
}
