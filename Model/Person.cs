using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model {
    public class Person {

        private int _id;
        public int Id {
            get { return _id; }
            set { _id = value;}
        }

        private string _firstName;
        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private string _zipCode;
        public string ZipCode {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _city;
        public string City {
            get { return _city; }
            set { _city = value; }
        }
        private string _Street;
        public string Street {
            get { return _Street; }
            set { _Street = value; }
        }

        private string _details;
        public string Details {
            get { return _details; }
            set { _details = value; }
        }
    }
}
