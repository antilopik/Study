using HomeWork.Models;
using HomeWork.Services;

namespace HomeWork.Tests.ServicesFakes;

internal sealed class FakeFileService : IFileService
{
    public GameResult? LastSavedResult { get; private set; }
    
    public void WriteLine(string filePath, GameResult result)
    {
        LastSavedResult = result;
    }

    public string[] ReadAllLines(string filePath)
    {
        return [];
    }

    public bool InsureFileExists(string filePath)
    {
        return false;
    }
}