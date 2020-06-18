using GalaSoft.MvvmLight;
using TestProject.Model;

namespace TestProject.ViewModel {
    public class PersonItem : ViewModelBase {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _city;

        public PersonItem(Person p) {
            FirstName = p.FirstName;
            LastName = p.LastName;
            City = p.City;
            Id = p.Id;
            _person = p;

        }

        private Person _person;

        public Person GetPerson()
        {
            return _person;
        }

        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        public string City
        {
            get => _city;
            set => Set(ref _city, value);
        }
       
    }
}
