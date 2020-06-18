using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using GVM = GalaSoft.MvvmLight.Messaging;
using TestProject.Tools;

namespace TestProject.ViewModel {
    public class TabA : ViewModelBase, ITabViewModel {
        private PersonItem _selectedPersonItem;
        public TabA() {
            Content = "List";
            OpenCommand = new RelayCommand(Open);
            PersonsList = new FileTools().LoadData();
        }
        public string Content { get; set; }
        public string Header { get; set; }
        public RelayCommand OpenCommand { get; set; }
        public ObservableCollection<PersonItem> PersonsList { get; set; }
        public PersonItem SelectedItem {
            get => _selectedPersonItem;
            set => Set(ref _selectedPersonItem, value);
        }
        private void Open() {
            GVM.Messenger.Default.Send(new MessageHelper { Id = SelectedItem.Id} );

        }
        

       
    }
}
