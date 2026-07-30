using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyCallories.Handlers;

namespace EasyCallories.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _targetCal = string.Empty;
        [ObservableProperty]
        private string _usedCal = string.Empty;
        [ObservableProperty]
        private string _addCaloriesToUsedCaloriesUserInput = string.Empty;
        [ObservableProperty]
        private string _calLeft = string.Empty;

        public HomeViewModel()
        {
            PopulateLabels();
        }

        private void PopulateLabels()
        {
            TargetCal = $"Target Calories 👉 {TomlHandler.ReadTomlField<int>("calTarget").ToString()}";
            UsedCal = $"Used Calories 👉 {TomlHandler.ReadTomlField<int>("calUsed").ToString()}";

            if (TomlHandler.ReadTomlField<int>("calTarget") == TomlHandler.ReadTomlField<int>("calUsed"))
            {
                CalLeft = "You hit the target 👍";
            }
            if (TomlHandler.ReadTomlField<int>("calUsed") < TomlHandler.ReadTomlField<int>("calTarget"))
            {
                int leftOverCal = TomlHandler.ReadTomlField<int>("calTarget") - TomlHandler.ReadTomlField<int>("calUsed");
                CalLeft = $"You have {leftOverCal} Cal left for today 😊";
            }
            if (TomlHandler.ReadTomlField<int>("calUsed") > TomlHandler.ReadTomlField<int>("calTarget"))
            {
                int calOver = TomlHandler.ReadTomlField<int>("calUsed") - TomlHandler.ReadTomlField<int>("calTarget");
                CalLeft = $"You over spend calories today by {calOver} 😞";
            }
        }

        [RelayCommand]
        private void AddCalories()
        {
            if (int.TryParse(AddCaloriesToUsedCaloriesUserInput, out int result))
            {
                TomlHandler.UpdateUsedCal(result);
                AddCaloriesToUsedCaloriesUserInput = "";
                PopulateLabels();
            }
        }
    }
}
