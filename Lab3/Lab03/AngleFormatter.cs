using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    public class AngleFormatter : IFormatProvider,ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (typeof(ICustomFormatter).Equals(formatType))
            {
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Angle a1 = new Angle();
            int decimalPlaces = 2;
            string formatString = string.Empty;
            string formatChar = string.Empty;

            if (arg == null)
            {
                throw new NullReferenceException("Value cannot be null;");
            }

            if (!(arg is Angle) )
            {
                if (arg is IFormattable)
                {
                    return ((IFormattable)arg).ToString(format, formatProvider);
                }
                else
                {
                    return arg.ToString();
                }
            }

            if (arg is Angle)
            {
                a1 = (Angle)arg;

                if (format == null || format[0] == 'c' || format[0] == 'C')
                {
                    switch (a1.Units)
                    {
                        case AngleUnits.Degrees:
                            format = "d";
                            break;
                        case AngleUnits.Gradians:
                            format = "g";
                            break;
                        case AngleUnits.Radians:
                            format = "r";
                            break;
                        case AngleUnits.Turns:
                            format = "t";
                            break;
                        default:
                            break;
                    }
                }

                formatChar = format[0].ToString();
                int length = format.Length;

                if ( length > 1)
                {
                    int formatInt = 0;
                    int.TryParse(format.Substring(1),out formatInt);
                    decimalPlaces = ExtensionMethods.Constrain(formatInt, 0, 9);
                }
                else if (length == 1)
                {
                    if (formatChar.ToLower() == "r" || formatChar.ToLower() == "p")
                    {
                        decimalPlaces = 5;
                    }
                    else
                    {
                        decimalPlaces = 2;
                    }
                }

                formatString = 'f' + decimalPlaces.ToString();

                switch (formatChar.ToLower())
                {
                    case ("d"):
                        a1 = a1.ToDegrees();
                        break;
                    case ("g"):
                        a1 = a1.ToGradians();
                        break;
                    case ("p"):
                        a1 = a1.ToRadians();
                        return string.Format($"{(a1.Value/Angle.pi).ToString(formatString)}π{a1.Units.ToSymbol()}");
                    case ("r"):
                        a1 = a1.ToRadians();
                        break;
                    case ("t"):
                        a1 = a1.ToTurns();
                        break;
                    default:
                        break;
                }
            }
            return a1.Value.ToString(formatString) + a1.Units.ToSymbol();
        }
    }
}
