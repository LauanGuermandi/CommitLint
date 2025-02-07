using System.Text.RegularExpressions;

namespace CommitLint.Validators;

public partial class CommitMessageValidator : ICommitMessageValidator
{
    [GeneratedRegex(@"^(feat|fix|docs|ci|style|refactor|test|chore)(\([\w\-]+\))?: .+$", RegexOptions.Compiled)]
    private static partial Regex CommitMessageRegex();

    public bool Validate(string commitMessage) => CommitMessageRegex().IsMatch(commitMessage);
}