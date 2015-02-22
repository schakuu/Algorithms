using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class LargeInt
    {
        long _thisVal = 0;
        LargeInt _overflow = null;

        public LargeInt(long value)
        {
            _thisVal = value;
        }

        public LargeInt(LargeInt copyFrom)
        {
            _thisVal = copyFrom._thisVal;
            if (copyFrom._overflow != null)
                _overflow = copyFrom._overflow;
        }

        public void Add(long value)
        {
            if (_overflow == null)
            {
                var _remainingSpace = long.MaxValue - _thisVal;
                if (_remainingSpace < value)
                {
                    // overflow will happen
                    _thisVal = long.MaxValue;
                    _overflow = new LargeInt(value - _remainingSpace);
                }
                else
                {
                    // no overflow
                    _thisVal += value;
                }
            }
            else
            {
                _overflow.Add(value);
            }
        }

        public void Add(LargeInt value)
        {
            if (value._overflow == null)
            {
                this.Add(value._thisVal);
            }
            else
            {
                this._overflow.Add(value);
            }

        }
        public override string ToString()
        {
            if (_overflow == null)
                return string.Format("{0}", _thisVal);
            return string.Format("{0}+{1}", _thisVal, _overflow.ToString()); 
        }
    }
}
