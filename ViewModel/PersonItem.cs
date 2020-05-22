using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject.ViewModel {
    public class PersonItem : ViewModelBase {

        public PersonItem(Person p) {
            _person.FirstName = p.FirstName;
            _person.LastName = p.LastName;
            _person.City = p.City;
            _person = p;
        }

        public Person _person { get; set; } = new Person();

        public int Id {
            get => _person.Id;
        }
        public string FirstName {
            get => _person.FirstName;
        }

        public string LastName {
            get => _person.LastName;
        }

        public string City {
            get => _person.City;
        }



    }
}
