using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TestProject.Tools;

namespace TestProject.ViewModel {

    public class MainViewModel : ViewModelBase {

        public MainViewModel() {

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<MessageHelper>(this, UpdateContent);
            
            TabViewModels = new ObservableCollection<ITabViewModel>();
            TabViewModels.Add(new TabA { Header = "Tab A" });
            TabViewModels.Add(new TabB { Header = "Tab B" });
            SelectedTabViewModel = TabViewModels[0];
        }

        public ObservableCollection<ITabViewModel> TabViewModels { get; set; }
       
        private ITabViewModel _selectedTab;
        public ITabViewModel SelectedTabViewModel {
            get => _selectedTab;
            set {
                _selectedTab = value;
                OnPropertyChanged("SelectedTabViewModel");
            }
        }
        public event PropertyChangedEventHandler MyPropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            MyPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateContent(MessageHelper message) {

            SelectedTabViewModel = TabViewModels[1];

        }

    }

    public interface ITabViewModel {
        string Header { get; set; }
    }
}