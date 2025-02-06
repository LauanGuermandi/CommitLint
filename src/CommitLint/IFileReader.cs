namespace CommitLint;

public interface IFileReader
{
    string ReadFile(string filePath);
    bool FileExists(string filePath);
}