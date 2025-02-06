namespace CommitLint.Output;

public interface IOutput
{
    void DisplayUsage();
    void DisplayError(string message);
    void DisplaySuccess();
    void DisplayInvalidCommitMessage();
    void DisplayExpectedFormat();
}