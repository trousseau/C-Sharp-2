using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class Person : ICloneable
    {
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        internal Person(int iD, string firstName, string lastName, DateTime dOB)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            DOB = dOB;
        }

        //copy constructor
        public Person(Person other) : this(other.ID, other.FirstName, other.LastName, other.DOB)
        {

        }

        public object Clone()
        {
            return new Person(this);
        }

        public int GetAge()
        {
            return DateTime.Now.Year - DOB.Year;
        }

        public string GetFormattedID()
        {
            string lastFour = string.Empty;
            int length = ID.ToString().Length - 1;
            lastFour = "XXX-XX-" + ID.ToString().Substring(length - 4, 4);
            return string.Format($"{lastFour}");
        }

        public override string ToString()
        {
            return string.Format($"{GetFormattedID(),-12} {FirstName,-10} {LastName,10} {DOB,-11:MM-dd-yyyy} {GetAge(),3}");
        }

        public static void GetHeader()
        {
            string id = "ID";
            string fName = "First";
            string lName = "Last";
            string dob = "DOB";
            string age = "Age";
            Console.WriteLine(string.Format($"{id,-12} {fName,-10} {lName,10} {dob,-11} {age,-3}"));
            string seperator = new string('=', 50);
            Console.WriteLine(seperator);
        }
    }
}
