using HomeWork.SOLID.Models;

namespace HomeWork.SOLID.Interfaces
{
    public interface ISettingsService
    {
        GameSettings LoadSettings();
        void SaveSettings(GameSettings settings);
    }
}
