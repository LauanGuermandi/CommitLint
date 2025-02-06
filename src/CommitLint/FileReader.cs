using System.IO;

namespace CommitLint;

public class FileReader : IFileReader
{
    public string ReadFile(string filePath)
        => File.ReadAllText(filePath);

    public bool FileExists(string filePath)
        => File.Exists(filePath);
}