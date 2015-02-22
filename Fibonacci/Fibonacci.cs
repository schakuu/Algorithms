using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Fibonacci
    {
        public int Fib1(int i)
        {
            if (i == 0) return 0;
            if (i == 1) return 1;

            return Fib1(i - 1) + Fib1(i - 2);
        }

        public long Fib2(int i, out long[] series)
        {
            series = new long[i + 1];
            return _Fib2(i, ref series);
        }

        long _Fib2(int i, ref long[] series)
        {
            if (i == 0) return 0;
            if (i == 1) return 1;

            if (i > 1)
            {
                series[0] = 0; series[1] = 1;
                for (var j = 2; j <= i; j++)
                    series[j] = series[j - 1] + series[j - 2];
            }
            return series[i];
        }

        public LargeInt Fib3(int i, out LargeInt[] series)
        {
            series = new LargeInt[i + 1];
            return _Fib3(i, ref series);
        }

        LargeInt _Fib3(int i, ref LargeInt[] series)
        {
            if (i == 0) return new LargeInt(0);
            if (i == 1) return new LargeInt(1);

            if (i > 1)
            {
                series[0] = new LargeInt(0);
                series[1] = new LargeInt(1);

                for (var j = 2; j <= i; j++)
                {
                    series[j] = new LargeInt(series[j - 1]);
                    series[j].Add(series[j - 2]);
                }
            }
            return series[i];
        }
    }
}
