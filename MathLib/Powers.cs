using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class Powers
    {
        const decimal MaxError = 0.000001m;

        public decimal Sqrt(decimal num)
        {
            decimal _upper = num;
            decimal _lower = 0.0m;

            decimal _sqr = 0; ;
            decimal _error = 0.1m;

            while (_error > MaxError)
            {
                _sqr = (_upper + _lower) / 2.0m;
                var _sq = _sqr * _sqr;
                if (_sq > num)
                {
                    _upper = _sqr;
                }
                else
                {
                    _lower = _sqr;
                }

                _error = (num - _sq) * (num - _sq);
            }

            return _sqr;
        }
    }
}
