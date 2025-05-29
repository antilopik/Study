using HomeWork.Models;

namespace HomeWork.Services;

public interface IFileService
{
    void WriteLine(string filePath, GameResult result);
    
    string[] ReadAllLines(string filePath);
    
    /// <summary>
    /// Checks if file exists and if not, creates it
    /// </summary>
    /// <param name="filePath">path to the file</param>
    /// <returns>true, if file existed</returns>
    bool InsureFileExists(string filePath);
}