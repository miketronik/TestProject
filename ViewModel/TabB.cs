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
using System.Windows;
using System.CodeDom;

namespace TestProject.ViewModel {
    public class TabB : ViewModelBase, ITabViewModel, IDataErrorInfo {

        //private PersonItem _selectedPersonItem;
        public Person Person = new Person();

        public TabB() {
            Content = "noch nichts passiert";
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<MessageHelper>(this, UpdateContent);
            SaveCommand = new RelayCommand(DoSave);
            DeleteCommand = new RelayCommand(Delete);
        }

        public string Header { get; set; }
        public string Content { get; set; }
        
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public ObservableCollection<PersonItem> MyList { get; set; }
        
        private void DoSave() { 
            MessageBox.Show("Speichern", FirstName + " " + LastName);
            //new FileTools().SaveData(MyList);

        }
        private void Delete() {
            MessageBox.Show("Wirklich löschen?", "Achtung", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }

        public void UpdateContent(MessageHelper message) {
            Content = $"{"Edit "+message.Message}";
            Person = new FileTools().GetPerson(message.Id);
            if (Person == null) {
                MessageBox.Show("Eintrag nicht gefunden");
                return;
            }
            
            GMM.Messenger.Default.Send(new MessageTabSelector { SelectedIndex = 1 });
            RaisePropertyChangedAll();
        }


        //########################################################################
        public void RaisePropertyChangedAll() {
            RaisePropertyChanged(() => FirstName);
            RaisePropertyChanged(() => LastName);
            RaisePropertyChanged(() => City);
            RaisePropertyChanged(() => Details);

        }

        public bool IsAdmin {
            get => true;
        }
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
        public DateTime? Birthdate {
            get => Person.BirthDate;
            set {
                Person.BirthDate = value;
                RaisePropertyChanged(() => Birthdate);
            }
        }
        public string Details {
            get => Person.Details;
            set {
                Person.Details = value;
                RaisePropertyChanged(() => Details);
            }
        }


        // implementierung IDataErrorInfo Interface

        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string this[string name] {
            get {
                string result = null;

                switch(name) {
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                            result = "Vorname darf nicht leer sein";
                        else if (FirstName.Length < 3)
                            result = "Vorname muss länger als 2 Zeichen sein";
                        break;
                }
                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                RaisePropertyChanged(() => ErrorCollection);
                return result;
            }
        }


    }
}
