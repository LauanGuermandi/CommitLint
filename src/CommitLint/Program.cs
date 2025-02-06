using CommitLint.Output;

namespace CommitLint;

internal class Program
{
    private static int Main(string[] args)
    {
        var commitLint = new CommitLint(new FileReader(), new Validators.CommitMessageValidator(), new ConsoleOutput());
        return commitLint.Execute(args);
    }
}