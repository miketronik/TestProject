using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Tools;

namespace TestProject.ViewModel {
    public class TabC : ViewModelBase, ITabViewModel {

        public TabC() {
            Content = "Tab C";
            FileOpenCommand = new RelayCommand(ShowFileChooser);
        }

        public string Header { get; set; }
        public string Content { get; set; }
        public RelayCommand FileOpenCommand { get; set; }
        private void ShowFileChooser() {

            //var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WorkshopWpf");
            //if (Directory.Exists(path)) {
            //    Process.Start(path);
            //}


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            Nullable<bool> FileDialogOk = openFileDialog.ShowDialog();
            string _fileNames ="";

            if (FileDialogOk == true) {
                
                foreach (string FileName in openFileDialog.FileNames) {
                    _fileNames += ";" + FileName;
                }
            }

        }
    
    }

}

