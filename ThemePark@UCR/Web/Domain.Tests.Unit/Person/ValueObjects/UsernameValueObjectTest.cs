using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Person.ValueObjects;
public class UsernameValueObjectTest
{
    [Fact]
    public void TryCreate_WithIllegalChars_ReturnsFalse()
    {
        // Arrange
        var inputValue = "Estudiante#256";
        // Act
        var result = UserNameValueObject.TryCreate(inputValue, out var userName);
        // Assert
        result.Should().BeFalse(
            because: "The username {0} contain illegal character(s)", inputValue);
    }
    [Fact]
    public void TryCreate_WithIncorrectLength_ReturnsFalse()
    {
        // Arrange
        var inputValue = "mnsflfnrlfnwflkngrklnldqwnkllfrnrlkwndlnqwdlnqlndlndkwdlqndnldknwldknqlwnflnelfnelfnelgenlnlndlflwnfewlnnlefnewl" +
            "efkbwfjbwfwkbwfribuiubgibqiwubiubeiubcibgirtnklnwlwlkncdcoengotgnotnnwelknklcnklnlnolntotnotnoeniownoeicncotgbhowehqwprnogrnoe xccmvvrorqnwore" +
            "qwqbqribgiqbpribpgbvpivqprbgihephrnfegpothpqhepoerghryubeyubeyufbvyufvqwuyvfeqwyufvuvqwfuvqwufvqwyuvfqwuvfuqwvbfhwbdvgfuebyvgfuwqyfbdgqewfuyqwvefuwv";
        // Act
        var result = UserNameValueObject.TryCreate(inputValue, out var userName);
        // Assert
        result.Should().BeFalse(
            because: "The username exceeded the limit length");
    }
    [Fact]
    public void TryCreate_WithCorrectUsername_ReturnsTrue()
    {
        // Arrange
        var inputValue = "Pedro";
        // Act
        var result = UserNameValueObject.TryCreate(inputValue, out var userName);
        // Assert
        result.Should().BeTrue(
            because: "The username {0} respect the creation rules", inputValue);
    }
    [Fact]
    public void TryCreate_WithEmptyUsername_ReturnsFalse()
    {
        // Arrange
        var inputValue = "";
        // Act
        var result = UserNameValueObject.TryCreate(inputValue, out var userName);
        // Assert
        result.Should().BeFalse(because: "The username is Empty");
    }
}
