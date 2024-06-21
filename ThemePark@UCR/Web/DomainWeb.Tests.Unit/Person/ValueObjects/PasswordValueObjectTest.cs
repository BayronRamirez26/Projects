using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.ValueObjects;

//TODO: define what tests should be done with the try create

public class PasswordValueObjectTest
{
    [Fact]
    public void TryCreate_WithSpecialCharacterAndValidLength_ReturnsTrue()
    {
        // Arrange
        var inputValue = "ValidPassword@123";
        // Act
        var result = PasswordValueObject.TryCreate(inputValue, out var password);
        // Assert 
        result.Should().BeTrue("because the value contains at least one special character and is within the valid length range");
    }

    [Fact]
    public void TryCreate_WithoutSpecialCharacter_ReturnsFalse()
    {
        // Arrange
        var inputValue = "ValidPassword123";  // No special characters
        // Act
        var result = PasswordValueObject.TryCreate(inputValue, out var password);
        // Assert 
        result.Should().BeFalse("because the password does not contain any special characters");
    }

    [Fact]
    public void TryCreate_WithInvalidLength_ReturnsFalse()
    {
        // Arrange
        var inputValue = "Short1!";
        // Act
        var result = PasswordValueObject.TryCreate(inputValue, out var password);
        // Assert 
        result.Should().BeFalse("because the password does not meet the length requirements");
    }
}
