using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestProject.Tools;

namespace TestProject.ViewModel {
    public class TabA : ViewModelBase, ITabViewModel {
        public TabA() {
            Content = "Tab A";
        }
        public string Content { get; set; }
        public string Header { get; set; }

        private ICommand actionCommand;
        public ICommand ActionCommand {
            get {
                return actionCommand = actionCommand ?? new MyRelayCommand(11);
            }
        }
    }
}
