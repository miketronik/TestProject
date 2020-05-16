using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Tools;

namespace TestProject.ViewModel {
    public class TabC : ViewModelBase, ITabViewModel {

        public TabC() {
            Content = "Tab C";
            
        }

        public string Header { get; set; }
        public string Content {get; set;}
    }
}
