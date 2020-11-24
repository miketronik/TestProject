using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Tools;

namespace TestProject.ViewModel {
    public class TabC : ViewModelBase, ITabViewModel {

        private ObservableCollection<string> _hsb_version = new ObservableCollection<string>();
        private String _hsbVersionSelectedItem;
        private int _selectedIndex = 0;

        public TabC() {
            Content = "Tab C";
            _hsb_version.Add("keine");
            _hsb_version.Add("1");
            _hsb_version.Add("2");
        }

        public string Header { get; set; }
        public string Content { get; set; }
        public RelayCommand FileOpenCommand { get; set; }


        public ObservableCollection<string> HSBVersion {
            get => _hsb_version;
            set {
                _hsb_version = value;
                RaisePropertyChanged(() => HSBVersion);
            }
        }
        public string HsbVersionSelectedItem {
            get => _hsbVersionSelectedItem;
            set {
                _hsbVersionSelectedItem = value;
                RaisePropertyChanged(() => HsbVersionSelectedItem);
            }
        }
        public int SelectedIndex {
            get => _selectedIndex;
            set {
                _selectedIndex = value;
                RaisePropertyChanged(() => SelectedIndex);
            }
        }

        public bool IsShowHsbOptions {
            get {
                return "1".Equals(HsbVersionSelectedItem) || "2".Equals(HsbVersionSelectedItem);
            }
        }
    }

}

