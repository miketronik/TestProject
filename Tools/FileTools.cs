using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestProject.Model;
using TestProject.ViewModel;

namespace TestProject.Tools {
    public class FileTools {

        private ObservableCollection<PersonItem> PersonsList { get; set; }

        public ObservableCollection<PersonItem> LoadData() {
            // XML-Datei deserialisieren
            string path = Directory.GetCurrentDirectory();
            int i = path.LastIndexOf("\\");
            path = path.Substring(0, i);
            i = path.LastIndexOf("\\");
            path = path.Substring(0, i) + "\\Persons.xml";

            if (File.Exists(path)) {
                PersonsList = new ObservableCollection<PersonItem>();
                FileStream fs = new FileStream(path, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
                ObservableCollection<Person> tempList = (ObservableCollection<Person>)serializer.Deserialize(fs);
                foreach (var item in tempList) {
                    PersonsList.Add(new PersonItem(item));
                }
                fs.Close();
            }
            return PersonsList;
        }

        public Person GetPerson(int id) {
            ObservableCollection<PersonItem> list = LoadData();
            foreach (PersonItem item in list) {
                if (item.GetPerson().Id.Equals(id)) {
                    return item.GetPerson(); 
                }
            }
            return null;
        }

        public void SaveData(ObservableCollection<PersonItem> PersonsList) {
            ObservableCollection<Person> person = new ObservableCollection<Person>();
            foreach (PersonItem item in PersonsList) {
                Person p = new Person();
                p.FirstName = item.GetPerson().FirstName;
                p.LastName = item.GetPerson().LastName;
                p.City = item.GetPerson().City;
                p.Details = item.GetPerson().Details;
                person.Add(p);
            }
            string path = Directory.GetCurrentDirectory();
            int i = path.LastIndexOf("\\");
            path = path.Substring(0, i);
            i = path.LastIndexOf("\\");
            path = path.Substring(0, i) + "\\Persons.xml";
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            serializer.Serialize(fs, person);
            fs.Close();
        }
    }
}
