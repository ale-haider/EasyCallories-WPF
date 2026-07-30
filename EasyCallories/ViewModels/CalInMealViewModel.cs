using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyCallories.Handlers;

namespace EasyCallories.ViewModels
{
    public partial class CalInMealViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _calPr100g = string.Empty;

        [ObservableProperty]
        private string _weightOfFood = string.Empty;

        [ObservableProperty]
        private string _calInMeal = string.Empty;

        [RelayCommand]
        private void Calculate()
        {
            if (double.TryParse(CalPr100g, out double resultPr100g) && (double.TryParse(WeightOfFood, out double resaultfoodWeight)))
            {

                double calPr1g = resultPr100g / 100;
                double calInFood = resaultfoodWeight * calPr1g;
                double roundedCalInFood = Math.Ceiling(calInFood);

                CalInMeal = $"Call in meal: {roundedCalInFood}";
            }
            else
            {
                CalInMeal = "Please enter a valid number.";
            }
        }

        [RelayCommand]
        private void AddToCalUsed()
        {
            if (double.TryParse(CalPr100g, out double resultPr100g) && (double.TryParse(WeightOfFood, out double resaultfoodWeight)))
            {

                double calPr1g = resultPr100g / 100;
                double calInFood = resaultfoodWeight * calPr1g;
                double roundedCalInFood = Math.Ceiling(calInFood);

                int newCalUsed = TomlHandler.ReadTomlField<int>("calUsed") + (int)roundedCalInFood;

                TomlHandler.UpdateTomlField("calUsed", newCalUsed);
                ClearAllFields();
            }
        }

        private void ClearAllFields()
        {
            CalPr100g = string.Empty;
            WeightOfFood = string.Empty;
            CalInMeal = string.Empty;
        }
    }
}
