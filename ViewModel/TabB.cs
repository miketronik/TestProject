using GalaSoft.MvvmLight;
using GMM = GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Tools;
using System.Collections.ObjectModel;
using TestProject.Model;
using GalaSoft.MvvmLight.Command;

namespace TestProject.ViewModel {
    public class TabB : ViewModelBase, ITabViewModel {

        private PersonItem _selectedPersonItem;

        public TabB() {
            Content = "noch nichts passiert";
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<MessageHelper>(this, UpdateContent);
            OpenCommand = new RelayCommand(Open);
        }

        public string Header { get; set; }
        public string Content { get; set; }
        public Person Person { get; set; }
        public RelayCommand OpenCommand { get; set; }
        public ObservableCollection<PersonItem> MyList { get; set; }
        
        public PersonItem SelectedItem {
            get => _selectedPersonItem;
            set => Set(ref _selectedPersonItem, value);
        }
        private void Open() {
            Person = new Person();
            var list = new LoadFile().LoadData();
            foreach (var item in list) {
                if (item.Id == SelectedItem.Id) {
                    Person = item._person;
                }
            }
        }

        public void UpdateContent(MessageHelper message) {
            Content = $"{"Edit "+message.Message}";
            MyList = new ObservableCollection<PersonItem>();
            ObservableCollection<PersonItem> list = message.PersonsList;
            Person = new Person();
            foreach (var item in list) {
                if (item.LastName.Equals(message.Message)) {
                    MyList.Add(item);
                }
            }
            Person = MyList.FirstOrDefault()._person;

            GMM.Messenger.Default.Send(new MessageTabSelector { SelectedIndex = 1 });
        }


        //########################################################################
        public string FirstName {
            get => Person.FirstName;
            set {
                Person.FirstName = value;
                RaisePropertyChanged(() => FirstName);
            }
        }
        public string LastName {
            get => Person.LastName;
            set {
                Person.LastName = value;
                RaisePropertyChanged(() => LastName);
            }
        }
        public string City {
            get => Person.City;
            set {
                Person.City = value;
                RaisePropertyChanged(() => City);
            }
        }
        public string Details {
            get => Person.Details;
            set {
                Person.Details = value;
                RaisePropertyChanged(() => Details);
            }
        }

    }
}
