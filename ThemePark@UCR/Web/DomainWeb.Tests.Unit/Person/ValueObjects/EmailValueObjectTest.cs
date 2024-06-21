using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.ValueObjects;

public class EmailValueObjectTest
{
    [Fact]
    public void TryCreate_WithCorrectValue_ReturnsTrue()
    {
        // Arrange
        string inputValue = "correocon@valido.com";
        // Act
        var result = EmailValueObject.TryCreate(inputValue, out var email);
        // Assert
        result.Should().BeTrue(
            because: "The value {0} respect the email creation rules", inputValue);
    }
    [Fact]
    public void TryCreate_WithIncorrectValue_ReturnsFalse()
    {
        // Arrange
        string inputValue = "correosinarroba";
        // Act
        var result = EmailValueObject.TryCreate(inputValue, out var email);
        // Assert
        result.Should().BeFalse(
            because: "The value {0} have a invalid email", inputValue);
    }
    [Fact]
    public void Create_WithCorrectObject_ReturnsTrue()
    {
        // Arrange
        var inputObject = "correo@test.com";
        // Act
        var result = EmailValueObject.Create(inputObject);
        // Assert
        result.Should().NotBeNull(
            because: "The object respect the email creation rules");
    }
}
