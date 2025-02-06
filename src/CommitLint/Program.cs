using CommitLint.Output;
using CommitLint.Validators;

namespace CommitLint;

internal class Program
{
    private static int Main(string[] args)
    {
        var commitLint = new CommitLint(new FileReader(), new CommitMessageValidator(), new ConsoleOutput());
        return commitLint.Execute(args);
    }
}