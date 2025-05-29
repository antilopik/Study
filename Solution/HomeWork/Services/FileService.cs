using System.IO;
using HomeWork.Models;

namespace HomeWork.Services;

public sealed class FileService : IFileService
{
    public void WriteLine(string filePath, GameResult result)
    {
        File.AppendAllLines(filePath, [result.ToString()]);
    }

    public string[] ReadAllLines(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

    /// <inheritdoc/>
    public bool InsureFileExists(string filePath)
    {
        bool fileExists = true;
        if (!File.Exists(filePath))
        {
            fileExists = false;
            var stream = File.Create(filePath);
            stream.Dispose();
        }

        return fileExists;
    }
}