using CommitLint.Output;
using CommitLint.Validators;

namespace CommitLint;

public class CommitLint(IFileReader fileReader, ICommitMessageValidator commitMessageValidator, IOutput output)
{
    public int Execute(string[] args)
    {
        if (args.Length != 1)
        {
            output.DisplayUsage();
            return 1;
        }

        var commitMessageFile = args[0];

        if (!fileReader.FileExists(commitMessageFile))
        {
            output.DisplayError($"File not found: [underline]{commitMessageFile}[/]");
            return 1;
        }

        var commitMessage = fileReader.ReadFile(commitMessageFile);
        var isValid = commitMessageValidator.Validate(commitMessage);

        if (isValid)
        {
            output.DisplaySuccess();
            return 0;
        }

        output.DisplayInvalidCommitMessage();
        output.DisplayExpectedFormat();
        return 1;
    }
}