using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;
using TestProject.ViewModel;

namespace TestProject.Tools {
    public class MessageHelper {

        public string Message { get; set; }
        public int Id { get; set; }
        public ObservableCollection<PersonItem> PersonsList { get; set; }
    }
}
