using EasyCallories.Model;

namespace EasyCallories.Handlers
{
    internal class TomlHandler
    {
        public static T ReadTomlField<T>(string tomlFieldToGetDataFrom)
        {

            if (typeof(T) == typeof(string))
            {
                return (T)(object)TomlModel.ReadTOMLfiels<string>(tomlFieldToGetDataFrom);
            }
            if (typeof(T) == typeof(int))
            {
                return (T)(object)TomlModel.ReadTOMLfiels<int>(tomlFieldToGetDataFrom);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)TomlModel.ReadTOMLfiels<bool>(tomlFieldToGetDataFrom);
            }

            throw new NotSupportedException($"The type {typeof(T).Name} is not supported by this method.");
        }

        public static void UpdateTomlField(string fieldToUpdate, int value)
        {
            TomlModel.UpdateTOMLFileFieldInt(fieldToUpdate, value);
        }

        public static void UpdateTomlField(string fieldToUpdate, string value)
        {
            TomlModel.UpdateTOMLFileFieldString(fieldToUpdate, value);
        }

        public static void UpdateUsedCal(int addCals)
        {
            int oldUsedCals = ReadTomlField<int>("calUsed");
            int newCalUsed = oldUsedCals + addCals;
            TomlHandler.UpdateTomlField("calUsed", newCalUsed);
        }
    }
}
