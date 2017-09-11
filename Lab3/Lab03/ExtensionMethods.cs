using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    public static class ExtensionMethods
    {
        public static bool ApproximatelyEquals(this decimal v1, decimal v2, decimal precision = 0.0000000001M)
        {
            decimal diff = Math.Abs(v1 - v2);

            if (diff < precision)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int Constrain(this int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }
            return value;
        }

        public static string ToSymbol(this AngleUnits units)
        {
            string symbol = string.Empty;
            switch (units)
            {
                case AngleUnits.Degrees:
                    symbol = "°";
                    break;
                case AngleUnits.Gradians:
                    symbol = "g";
                    break;
                case AngleUnits.Radians:
                    symbol = "rad";
                    break;
                case AngleUnits.Turns:
                    symbol = "tr";
                    break;
            }
            return symbol;
        }

    }
}
