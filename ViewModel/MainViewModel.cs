using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TestProject.Tools;

namespace TestProject.ViewModel {

    public class MainViewModel : ViewModelBase {
        private ObservableCollection<ITabViewModel> _tabViewModels;
        private ITabViewModel _selectedTabViewModel;
        private int _selectedIndex;

        public MainViewModel() {

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<MessageTabSelector>(this, FocusTabItem);
            
            TabViewModels = new ObservableCollection<ITabViewModel>();
            TabViewModels.Add(new TabA { Header = "Tab A" });
            TabViewModels.Add(new TabB { Header = "Tab B" });
            TabViewModels.Add(new TabC { Header = "Tab C" });
            SelectedTabViewModel = TabViewModels[0];
        }

        public ObservableCollection<ITabViewModel> TabViewModels {
            get => _tabViewModels;
            set => Set(ref _tabViewModels, value);
        }

        public ITabViewModel SelectedTabViewModel {
            get => _selectedTabViewModel;
            set => Set(ref _selectedTabViewModel, value);
        }
        //public event PropertyChangedEventHandler MyPropertyChanged;

        public int SelectedIndex {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }
        private void FocusTabItem(MessageTabSelector tb) {
            SelectedIndex = tb.SelectedIndex;

            //if (SelectedIndex == 0) {
            //    SelectedIndex = 1;
            //} else {
            //    SelectedIndex = 0;
            //}
        }
    }

    public interface ITabViewModel {
        string Header { get; set; }
    }
}