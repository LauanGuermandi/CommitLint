namespace CommitLint.Validators;

public interface ICommitMessageValidator
{
    bool Validate(string commitMessage);
}