using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.ValueObjects;

public class PhoneValueObjectTest
{
    [Fact]
    public void TryCreate_WithCorrectValue_ReturnsTrue()
    {
        // Arrange
        string inputValue = "1234-5678";
        // Act
        var result = PhoneValueObject.TryCreate(inputValue, out var phoneNumber);
        // Assert
        result.Should().BeTrue(
            because: "The value {0} respect the phone number creation rules", inputValue);
    }
    [Fact]
    public void TryCreate_WithIncorrectValue_ReturnsFalse()
    {
        // Arrange
        string inputValue = "";
        // Act
        var result = PhoneValueObject.TryCreate(inputValue, out var phoneNumber);
        // Assert
        result.Should().BeFalse(
            because: "The value {0} have a invalid phone number", inputValue);
    }
    [Fact]
    public void Create_WithCorrectObject_ReturnsTrue()
    {
        // Arrange
        var inputObject = "1234-5678";
        // Act
        var result = PhoneValueObject.Create(inputObject);
        // Assert
        result.Should().NotBeNull(
            because: "The object respect the phone number creation rules");
    }
}
