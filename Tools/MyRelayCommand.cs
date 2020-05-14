using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestProject.ViewModel;

namespace TestProject.Tools {
    public class MyRelayCommand : ICommand {
        private int value;
        public MyRelayCommand(int controlAViewModel) {
            this.value = controlAViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) {
            if (parameter is null)
                return;
            MessageHelper messageName = new MessageHelper { Message = parameter.ToString() + ", " + this.value };
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(messageName);

        }
    }
}