using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> pList = new List<Person>();

            PersonFactory factory = PersonFactory.PFInstance;

            Person p1 = factory.Create(123456789, "Homer", "Simpson", DateTime.Parse("5/12/1956"));
            pList.Add(p1);
            Person p2 = factory.Create(987654321, "Elliot", "Alderson", DateTime.Parse("9/17/1986"));
            pList.Add(p2);
            Person p3 = p1.Clone() as Person;
            p3.FirstName = "Jon";
            p3.LastName = "Snow";
            p3.DOB = DateTime.Parse("1/1/1989");
            pList.Add(p3);
            Person p4 = factory.Create(102938475, "Dale", "Cooper", DateTime.Parse("4/19/1954"));
            pList.Add(p4);
            Person p5 = factory.Create(121212121, "Saul", "Goodman", DateTime.Parse("1/1/1961"));
            pList.Add(p5);

            Person.GetHeader();
            foreach (var person in pList)
            {
                Console.WriteLine(person.ToString());
            }

            Console.ReadLine();
        }
    }
}
