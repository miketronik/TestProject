
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;


namespace TestProject.ViewModel {

    public class ViewModelLocator {
        
        public ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TabA>();
            SimpleIoc.Default.Register<TabC>();
        }

        public MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public TabA TabA {
            get {
                return ServiceLocator.Current.GetInstance<TabA>();
            }
        }
        public TabC TabB {
            get {
                return ServiceLocator.Current.GetInstance<TabC>();
            }
        }
        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }
}