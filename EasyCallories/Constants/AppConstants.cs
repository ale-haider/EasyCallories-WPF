using System.IO;

namespace EasyCallories.Constants
{
    public static class AppConstants
    {
        public static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "Config.toml");
        public static string TodaysDateOnly => DateOnly.FromDateTime(DateTime.Today).ToString().ToString();
    }
}
