using CommitLint.Output;
using CommitLint.Validators;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Shouldly;

namespace CommitLint.UnitTests;

public class CommitLintTests
{
    private readonly IFileReader _fileReader = Substitute.For<IFileReader>();
    private readonly ICommitMessageValidator _commitMessageValidator = Substitute.For<ICommitMessageValidator>();
    private readonly IOutput _output = Substitute.For<IOutput>();

    [Fact]
    public void Execute_ShouldDisplayUsage_WhenArgumentsAreNotCorrect()
    {
        // Arrange
        var commitLint = new CommitLint(_fileReader, _commitMessageValidator, _output);

        // Act
        var result = commitLint.Execute([]);

        // Assert
        _output.Received(1).DisplayUsage();
        result.ShouldBe(1);
    }

    [Fact]
    public void Execute_ShouldDisplayError_WhenFileDoesNotExist()
    {
        // Arrange
        _fileReader
            .ReadFile(Arg.Any<string>())
            .Throws<FileNotFoundException>();

        var commitLint = new CommitLint(_fileReader, _commitMessageValidator, _output);

        // Act
        var result = commitLint.Execute(["nonexistent-file.txt"]);

        // Assert
        _output.Received(1).DisplayError(Arg.Any<string>());
        result.ShouldBe(1);
    }

    [Fact]
    public void Execute_ShouldDisplaySuccess_WhenCommitMessageIsValid()
    {
        // Arrange
        _fileReader
            .FileExists(Arg.Any<string>())
            .Returns(true);

        _fileReader
            .ReadFile(Arg.Any<string>())
            .Returns("feat(auth): add OAuth support");

        _commitMessageValidator
            .Validate(Arg.Any<string>())
            .Returns(true);

        var commitLint = new CommitLint(_fileReader, _commitMessageValidator, _output);

        // Act
        var result = commitLint.Execute(["valid-commit.txt"]);

        // Assert
        _output.Received(1).DisplaySuccess();
        result.ShouldBe(0);
    }

    [Fact]
    public void Execute_ShouldDisplayInvalidCommitMessage_WhenCommitMessageIsInvalid()
    {
        // Arrange
        _fileReader
            .FileExists(Arg.Any<string>())
            .Returns(true);

        _fileReader
            .ReadFile(Arg.Any<string>())
            .Returns("invalid commit message");

        _commitMessageValidator
            .Validate(Arg.Any<string>())
            .Returns(false);

        var commitLint = new CommitLint(_fileReader, _commitMessageValidator, _output);

        // Act
        var result = commitLint.Execute(["invalid-commit.txt"]);

        // Assert
        _output.Received(1).DisplayInvalidCommitMessage();
        _output.Received(1).DisplayExpectedFormat();
        result.ShouldBe(1);
    }
}
