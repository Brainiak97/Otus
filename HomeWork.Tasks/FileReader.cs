using System.IO;
using System.Text.RegularExpressions;

namespace TaskHomeWork;

public static partial class FileReader
{
    /// <summary>
    /// Read three files in directory of app
    /// </summary>
    public static async Task<int> GetSpaceFromThreeFilesInAppDirectory()
    {
        var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        var files = Directory.GetFiles(directoryPath, "*.txt");

        List<Task<int>> tasks = [];
        foreach (var file in files.Take(3))
        {
            tasks.Add(GetSpacesFromFileAsync(file));
        }

        int[] results = await Task.WhenAll(tasks);

        return results.Sum();
    }

    /// <summary>
    /// Read all files in some directory
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <returns></returns>
    public static async Task<int> GetSpaceFromAllFilesInSomeDirectory(string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath, "*.txt");

        List<Task<int>> tasks = [];
        foreach (var file in files)
        {
            tasks.Add(GetSpacesFromFileAsync(file));
        }

        int[] results = await Task.WhenAll(tasks);

        return results.Sum();
    }

    private static async Task<int> GetSpacesFromFileAsync(string filePath)
    {
        using StreamReader reader = new(filePath);
        string text = await reader.ReadToEndAsync();

        return SpaceRegex().Count(text);
    }

    [GeneratedRegex(" ")]
    private static partial Regex SpaceRegex();
}
