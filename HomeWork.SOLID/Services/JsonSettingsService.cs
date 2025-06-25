using HomeWork.SOLID.Interfaces;
using HomeWork.SOLID.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace HomeWork.SOLID.Services
{
    public class JsonSettingsService(string filePath) : ISettingsService
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        private readonly string _filePath = filePath;

        public GameSettings LoadSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_filePath, optional: false, reloadOnChange: true)
                .Build();

            var settings = new GameSettings();
            config.GetSection("GameSettings").Bind(settings);
            return settings;
        }

        public void SaveSettings(GameSettings settings)
        {
            var json = new JsonObject
            {
                ["GameSettings"] = new JsonObject
                {
                    ["MinValue"] = settings.MinValue,
                    ["MaxValue"] = settings.MaxValue,
                    ["Attempts"] = settings.Attempts
                }
            };

            string jsonString = JsonSerializer.Serialize(json, _options);
            File.WriteAllText(_filePath, jsonString);
        }
    }
}
