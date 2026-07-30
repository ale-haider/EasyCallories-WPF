using EasyCallories.Constants;
using EasyCallories.Model;

namespace EasyCallories.Handlers
{
    internal class AppStartupHandler
    {
        public static void StartupChecks()
        {
            CheckConfigFile();
            ResetUsedCal();
        }

        private static void CheckConfigFile()
        {
            if (!TomlModel.CheckIfTOMLFileExist())
            {
                TomlModel.MakeTOMLFile();
            }
        }

        private static void ResetUsedCal()
        {
            string storedDate = TomlHandler.ReadTomlField<string>("todaysDate");
            string todaysDate = AppConstants.TodaysDateOnly;

            if (!storedDate.Equals(todaysDate))
            {
                TomlModel.CalReset();
                TomlModel.UpdateTOMLFileFieldString("todaysDate", todaysDate);
            }
        }
    }
}
