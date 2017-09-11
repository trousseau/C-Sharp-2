using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Rectangles:");
            Rectangle r1 = new Rectangle(new Point(3, 4), new Point(7, 9));
            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"Perimeter: {r1.Perimeter()} Area: {r1.Area()}");
            Console.WriteLine();
            Rectangle r2 = new Rectangle(new Point(3, 4), new Point(7, 9), new Point(-2, -2), new Point(8, 1));
            Console.WriteLine($"r2: {r2}");
            Console.WriteLine($"Perimeter: {r2.Perimeter()} Area: {r2.Area()}");
            Console.WriteLine();
            Console.WriteLine("Triangles:");
            Triangle t1 = new Triangle(new Point(1, -4), new Point(9, 1), new Point(3, 4));
            Console.WriteLine($"t1: {t1}");
            Console.WriteLine($"t1 is scalene? {t1.IsScalene()}");
            Console.WriteLine($"t1 is isosceles? {t1.IsIsosceles()}");
            Console.WriteLine($"t1 is equilateral? {t1.IsEquilateral()}");
            Console.WriteLine($"Perimeter: {t1.Perimeter()} Area: {t1.Area()}");
            Console.WriteLine();
            Triangle t2 = new Triangle(new Point(10, 0), new Point(0, 10), new Point(0, 0));
            Console.WriteLine($"t2: {t2}");
            Console.WriteLine($"t2 is scalene? {t2.IsScalene()}");
            Console.WriteLine($"t2 is isosceles? {t2.IsIsosceles()}");
            Console.WriteLine($"t2 is equilateral? {t2.IsEquilateral()}");
            Console.WriteLine($"Perimeter: {t2.Perimeter()} Area: {t2.Area()}");
            Console.WriteLine();
            Triangle t3 = new Triangle(new List<Point>() { new Point(0, 0), new Point(10, 0), new Point(5, 8.660254037845) });
            Console.WriteLine($"t3: {t3}");
            Console.WriteLine($"t3 is scalene? {t3.IsScalene()}");
            Console.WriteLine($"t3 is isosceles? {t3.IsIsosceles()}");
            Console.WriteLine($"t3 is equilateral? {t3.IsEquilateral()}");
            Console.WriteLine($"Perimeter: {t3.Perimeter()} Area: {t3.Area()}");
            Console.WriteLine();
            Console.WriteLine("Shapes:");
            List<Shape> shapes = new List<Shape>() { r1, r2, t1, t2, t3 };
            foreach (Shape s in shapes)
            {
                Console.WriteLine(s);
                Console.WriteLine($"Perimeter: {s.Perimeter()} Area: {s.Area()}");
            }
            Console.WriteLine();
            Console.WriteLine("Split r1:");
            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"Perimeter: {r1.Perimeter()} Area: {r1.Area()}");

            var triangles = r1.ToTriangles();
            foreach (Triangle t in triangles)
            {
                Console.WriteLine(t);
                Console.WriteLine($"Perimeter: {t.Perimeter()} Area: {t.Area()}");
            }
            double area = triangles[0].Area() + triangles[1].Area();
            Console.WriteLine($"r1 area == combined triangle area?: {Utils.IsRelativelyEqual(area, r1.Area())}");

            Console.Write("Press <ENTER> to quit...");
            Console.ReadLine();

        }
    }
}
