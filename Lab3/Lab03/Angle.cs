using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Angle : IFormattable
    {
        #region Properties

        public const decimal pi = 3.1415926535897932384626434M;
        public const decimal twoPi = 2M * pi;

        private decimal _Value = 0M;
        private AngleUnits _Units = AngleUnits.Degrees;
        private static decimal[,] _ConversionFactors = {
            { 1M, 9M / 10M, 180M / pi, 360M},
            { 10M / 9M, 1M, 200M / pi, 400M},
            { pi / 180M, pi / 200M, 1M, twoPi},
            { 1M / 360M, 1M / 400M, 1M / twoPi, 1M}};

        public decimal Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = Normalize(value, Units);
            }
        }
        public AngleUnits Units
        {
            get
            {
                return _Units;
            }
            set
            {
                _Value = ConvertAngleValue(Value, Units, value);
                _Units = value;
            }
        }
        #endregion

        #region Constructors

        public Angle() : this(0,AngleUnits.Degrees)
        {

        }
        public Angle(Angle other) : this(other.Value, other.Units)
        {

        }
        public Angle(decimal value, AngleUnits units = AngleUnits.Degrees)
        {
            Units = units;
            Value = value;
        }

        #endregion

        #region Methods

        private static decimal Normalize(decimal value, AngleUnits units)
        {
            switch (units)
            {
                case(AngleUnits.Degrees):
                    while (value < 0 || value > 360)
                    {
                        if (value < 0)
                        {
                            value += 360;
                        }
                        else if (value > 360)
                        {
                            value -= 360;
                        }
                    }
                    break;
                case (AngleUnits.Gradians):
                    while (value < 0 || value > 400)
                    {
                        if (value < 0)
                        {
                            value += 400;
                        }
                        else if (value > 400)
                        {
                            value -= 400;
                        }
                    }
                    break;
                case (AngleUnits.Radians):
                    while (value < 0 || value > twoPi)
                    {
                        if (value < 0)
                        {
                            value += twoPi;
                        }
                        else if (value > twoPi)
                        {
                            value -= twoPi;
                        }
                    }
                    break;
                case (AngleUnits.Turns):
                    while (value < 0 || value > 1)
                    {
                        if (value < 0)
                        {
                            value += 1;
                        }
                        else if (value > 1)
                        {
                            value -= 1;
                        }
                    }
                    break;
            }
            return value;
        }

        private static decimal ConvertAngleValue(decimal angle, AngleUnits fromUnits, AngleUnits toUnits)
        {
            decimal factor = _ConversionFactors[(int)toUnits, (int)fromUnits];

            decimal convertedAngle = factor * angle;

            return Normalize(convertedAngle, toUnits);
            ;
        }

        public Angle ToDegrees()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Degrees), AngleUnits.Degrees);
        }

        public Angle ToGradians()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Gradians), AngleUnits.Gradians);
        }

        public Angle ToRadians()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Radians), AngleUnits.Radians);
        }

        public Angle ToTurns()
        {
            return new Angle(ConvertAngleValue(Value, Units, AngleUnits.Turns), AngleUnits.Turns);
        }

        public Angle ConvertAngle(AngleUnits targetUnits)
        {
            Angle angle = new Angle();
            switch (targetUnits)
            {
                case AngleUnits.Degrees:
                    angle = ToDegrees();
                    break;
                case AngleUnits.Gradians:
                    angle = ToGradians();
                    break;
                case AngleUnits.Radians:
                    angle = ToRadians();
                    break;
                case AngleUnits.Turns:
                    angle = ToTurns();
                    break;
            }
            return angle;
        }

        #endregion

        #region ArithmeticOperators

        public static Angle operator +(Angle a1, Angle a2)
        {
            var convertedA2 = ConvertAngleValue(a2.Value, a2.Units, a1.Units);
            var sum = convertedA2 + a1.Value;
            return new Angle(sum, a1.Units);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            var convertedA2 = ConvertAngleValue(a2.Value, a2.Units, a1.Units);
            var diff = convertedA2 - a1.Value;
            return new Angle(diff, a1.Units);
        }

        public static Angle operator +(Angle a, decimal scalar)
        {
            decimal angleSum = a.Value + scalar;
            return new Angle(angleSum, a.Units);
        }

        public static Angle operator -(Angle a, decimal scalar)
        {
            decimal angleDiff = a.Value - scalar;
            return new Angle(angleDiff, a.Units);
        }

        public static Angle operator *(Angle a, decimal scalar)
        {
            decimal angleProduct = a.Value * scalar;
            return new Angle(angleProduct, a.Units);
        }

        public static Angle operator /(Angle a, decimal scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException("Value cannot be 0");
            }
            decimal angleQuotient = a.Value / scalar;
            return new Angle(angleQuotient, a.Units);
        }

        #endregion

        #region ComparisonOperators

        public static bool operator == (Angle a, Angle b)
        {
            object o1 = a;
            object o2 = b;
            if (o1 == null && o2 == null) return true;
            if (o1 == null ^ o2 == null) return false;
            Angle normAngle = b.ConvertAngle(a.Units);
            return a.Value.ApproximatelyEquals(normAngle.Value);
        }

        public static bool operator != (Angle a, Angle b)
        {
            return !(a == b);
        }

        public static bool operator < (Angle a, Angle b)
        {
            if (a == null && b == null) return false;
            if (a == null && b != null) return true;
            if (a != null && b == null) return false;
            Angle normAngle = b.ConvertAngle(a.Units);
            return !(a.Value.ApproximatelyEquals(normAngle.Value)) && (a.Value < normAngle.Value);
        }

        public static bool operator > (Angle a, Angle b)
        {
            return !(a == b || a < b);
        }

        public static bool operator <= (Angle a, Angle b)
        {
            return (a < b || a == b);
        }

        public static bool operator >= (Angle a, Angle b)
        {
            return (a > b || a == b);
        }

        #endregion

        public override bool Equals(object obj)
        {
            return this == obj as Angle;
        }

        public override int GetHashCode()
        {
            return ConvertAngleValue(Value, Units, AngleUnits.Degrees).GetHashCode();
        }

        public static explicit operator decimal(Angle a)
        {
            return a.Value;
        }

        public static explicit operator double(Angle a)
        {
            return (double)a.Value;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return new AngleFormatter().Format(format, this, formatProvider);
        }

        public string ToString(string format)
        {
            AngleFormatter fmt = new AngleFormatter();
            return fmt.Format(format, this, fmt);
        }

        public override string ToString()
        {
            return ToString(string.Empty);
        }
    }
}
