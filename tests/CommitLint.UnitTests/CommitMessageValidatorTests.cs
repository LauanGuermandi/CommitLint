using CommitLint.Validators;
using Shouldly;

namespace CommitLint.UnitTests;

public class CommitMessageValidatorTests
{
    [Theory]
    [InlineData("feat(auth): add OAuth support", true)]
    [InlineData("fix(core): fix bug with user login", true)]
    [InlineData("docs(readme): update documentation", true)]
    [InlineData("style(button): adjust button colors", true)]
    [InlineData("refactor(database): optimize queries", true)]
    [InlineData("test(unit): add unit tests for CommitMessageValidator", true)]
    [InlineData("chore(release): bump version to 1.0.1", true)]
    [InlineData("ci: fix pipeline sonar step", true)]
    [InlineData("feat: add new feature without scope", true)]
    [InlineData("invalid message format", false)]
    [InlineData("fix(auth)fix bug", false)]
    [InlineData("fix(auth):", false)]
    public void Validate_CommitMessage_ShouldReturnExpectedResult(string commitMessage, bool expectedResult)
    {
        // Act
        var result = new CommitMessageValidator().Validate(commitMessage);

        // Assert
        result.ShouldBe(expectedResult);
    }
}