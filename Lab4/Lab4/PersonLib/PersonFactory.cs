using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class PersonFactory
    {
        private static PersonFactory _PFInstance = null;

        static PersonFactory()
        {
            _PFInstance = new PersonFactory();
        }

        private PersonFactory()
        {

        }

        public static PersonFactory PFInstance
        {
            get
            {
                return _PFInstance;
            }
            private set
            {
                _PFInstance = value;
            }
        }

        public Person Create(int id, string firstName, string lastName, DateTime dob)
        {
            return new Person(id, firstName, lastName, dob);
        }
    }
}
