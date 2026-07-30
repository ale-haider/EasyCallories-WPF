using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyCallories.Handlers;

namespace EasyCallories.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _newCalTarget = "New cal target 👉";

        [ObservableProperty]
        private string _setNewCalTargetString = string.Empty;

        [RelayCommand]
        private void SetNewTarget()
        {
            if (SetNewCalTargetString.IsWhiteSpace())
            {
                NewCalTarget = "👇The input field is empty!!👇";
            }
            else
            {
                NewCalTarget = $"Target cal 👉 {SetNewCalTargetString}";
                if (int.TryParse(SetNewCalTargetString, out int value))
                {
                    TomlHandler.UpdateTomlField("calTarget", value);
                    SetNewCalTargetString = string.Empty;
                }
            }
        }
    }
}
