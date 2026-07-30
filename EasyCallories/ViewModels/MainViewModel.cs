using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EasyCallories.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentView;

        public MainViewModel()
        {
            _currentView = new HomeViewModel();
        }

        [RelayCommand]
        private void SwitchView(string destination)
        {
            switch (destination)
            {
                case "Home":
                    CurrentView = new HomeViewModel();
                    break;

                case "Settings":
                    CurrentView = new SettingsViewModel();
                    break;

                case "CalInMeal":
                    CurrentView = new CalInMealViewModel();
                    break;

                case "About":
                    CurrentView = new AboutViewModel();
                    break;

                default:
                    CurrentView = new HomeViewModel();
                    break;
            }
        }
    }
}
