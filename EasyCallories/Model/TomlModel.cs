using EasyCallories.Constants;
using System.IO;
using Tommy;

namespace EasyCallories.Model
{
    internal class TomlModel
    {
        private static TomlTable? toml;
        public static void MakeTOMLFile()
        {
            string todaysDate = AppConstants.TodaysDateOnly;

            TomlTable toml = new TomlTable
            {
                ["todaysDate"] = todaysDate,
                ["calTarget"] = 00,
                ["calUsed"] = 00,
            };

            string filePath = AppConstants.ConfigFilePath;

            using (StreamWriter writer = File.CreateText(filePath))
            {
                toml.WriteTo(writer);
                writer.Flush();
            }
        }

        public static void UpdateTOMLFileFieldString(string fieldToUpdate, string newValue)
        {
            if (CheckIfTOMLFileExist())
            {
                LoadeConfigFile();

                toml?[fieldToUpdate] = newValue;

                using (StreamWriter writer = File.CreateText(AppConstants.ConfigFilePath))
                {
                    toml?.WriteTo(writer);
                    writer.Flush();
                }
            }
        }

        public static void UpdateTOMLFileFieldInt(string fieldToUpdate, int newValue)
        {
            if (CheckIfTOMLFileExist())
            {
                LoadeConfigFile();

                toml?[fieldToUpdate] = newValue;

                using (StreamWriter writer = File.CreateText(AppConstants.ConfigFilePath))
                {
                    toml?.WriteTo(writer);
                    writer.Flush();
                }
            }
        }

        public static bool CheckIfTOMLFileExist()
        {
            return Path.Exists(AppConstants.ConfigFilePath);
        }

        public static T ReadTOMLfiels<T>(string TOMLFieldToGetDataFrom)
        {
            if (!CheckIfTOMLFileExist())
            {
                throw new FileNotFoundException("TOML configuration file not found.");
            }

            LoadeConfigFile();

            if (!toml.HasKey(TOMLFieldToGetDataFrom))
            {
                throw new KeyNotFoundException($"The key '{TOMLFieldToGetDataFrom}' was not found.");
            }

            TomlNode node = toml[TOMLFieldToGetDataFrom];

            if (typeof(T) == typeof(string))
            {
                return (T)(object)node.AsString.Value;
            }
            if (typeof(T) == typeof(int))
            {
                return (T)(object)(int)node.AsInteger.Value;
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)node.AsBoolean.Value;
            }

            throw new NotSupportedException($"The type {typeof(T).Name} is not supported by this method.");
        }

        public static void CalReset()
        {
            UpdateTOMLFileFieldInt("calUsed", 00);
        }

        private static void LoadeConfigFile()
        {
            using StreamReader reader = File.OpenText(AppConstants.ConfigFilePath);
            toml = TOML.Parse(reader);
        }
    }
}
