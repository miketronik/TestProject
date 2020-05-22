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
    public class LoadFile {

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
    }
}
