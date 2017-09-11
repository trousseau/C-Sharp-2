using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Basic Angle Manipulation");
            Angle a1 = new Angle(60, AngleUnits.Degrees);
            Console.WriteLine($"a1: {a1}");
            a1 += 30M;
            Console.WriteLine($"a1: {a1}");
            Angle a2 = new Angle(Angle.pi / 4M, AngleUnits.Radians);
            Console.WriteLine($"a2: {a2}");
            a2 *= 2M;
            Console.WriteLine($"a2: {a2}");
            Angle a3 = new Angle(100, AngleUnits.Gradians);
            Console.WriteLine($"a3: {a3}");
            a3 += a2;
            Console.WriteLine($"a3: {a3}");
            Angle a4 = new Angle(0.25M, AngleUnits.Turns);
            Console.WriteLine($"a4: {a4}");
            a4 /= 2M;
            Console.WriteLine($"a4: {a4}");
            Console.WriteLine();
            Console.WriteLine($"a4 (multi-format): {a4:d} {a4:g} {a4:p} {a4:r} {a4:t}");
            Console.WriteLine();
            Console.WriteLine("Angle Comparisons");
            Console.WriteLine($"{a1} < {a2}? {a1 < a2}");
            Console.WriteLine($"{a1} > {a2}? {a1 > a2}");
            Console.WriteLine($"{a1} == {a2}? {a1 == a2}");
            Console.WriteLine($"{a1} != {a2}? {a1 != a2}");
            Console.WriteLine($"{a1} < {a3}? {a1 < a3}");
            Console.WriteLine($"{a1} > {a3}? {a1 > a3}");
            Console.WriteLine($"{a1} == {a3}? {a1 == a3}");
            Console.WriteLine($"{a1} != {a3}? {a1 != a3}");
            Console.WriteLine();
            Console.WriteLine("Angle Conversions");
            Angle a = new Angle(90, AngleUnits.Degrees);
            Angle orig = new Angle(a);
            Console.WriteLine($"a as degrees: {a}");
            a = a.ToGradians();
            Console.WriteLine($"a as gradians: {a}");
            a = a.ToRadians();
            Console.WriteLine($"a as radians: {a}");
            a = a.ToTurns();

            Console.WriteLine($"a as turns: {a}");
            a = a.ToDegrees();
            Console.WriteLine($"a as degrees again: {a}");
            Console.WriteLine($"a == orig? {a.Value.ApproximatelyEquals(orig.Value)}");
            Console.WriteLine();
            Console.WriteLine("Multiple Modifications");
            a.Units = AngleUnits.Turns;
            for (int i = 0; i < 10; ++i)
            {
                a -= .20m;
                Console.WriteLine(a);
            }


            Console.Write("Press <ENTER> to quit...");
            Console.ReadLine();
        }
    }
}
