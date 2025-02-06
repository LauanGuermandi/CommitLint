using Spectre.Console;

namespace CommitLint.Output;

public class ConsoleOutput : IOutput
{
    public void DisplayUsage()
        => AnsiConsole.MarkupLine("[bold red]Usage:[/] CommitLint <commit-message-file>");

    public void DisplayError(string message)
        => AnsiConsole.MarkupLine($"[bold red]Error:[/] {message}");

    public void DisplaySuccess()
        => AnsiConsole.MarkupLine("[bold green]✔ Commit message is valid![/]");

    public void DisplayInvalidCommitMessage()
        => AnsiConsole.MarkupLine("[bold red]✘ Invalid commit message format![/]");

    public void DisplayExpectedFormat()
        => AnsiConsole.MarkupLine("[bold yellow]Expected format:[/] [blue]type(scope): subject[/]");
}