using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Tools;

namespace TestProject.ViewModel {
    public class TabB : ViewModelBase, ITabViewModel {

        public TabB() {
            Content = "noch nichts passiert";
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<MessageHelper>(this, UpdateContent);

        }

        public string Header { get; set; }
        public event PropertyChangedEventHandler MyPropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            MyPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _content;
        public string Content {
            get => _content;
            set {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
        public void UpdateContent(MessageHelper message) {
            Content = $"{message.Message} Pressed";
        }
    }
}
