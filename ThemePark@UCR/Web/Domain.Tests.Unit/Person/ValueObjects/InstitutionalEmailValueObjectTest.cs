using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Person.ValueObjects;

public class InstitutionalEmailValueObjectTest
{
    [Fact]
    public void TryCreate_WithCorrectValue_ReturnsTrue()
    {
        // Arrange
        string inputValue = "correoinstitucional@ucr.ac.cr";
        // Act
        var result = InstitutionalEmailValueObject.TryCreate(inputValue, out var email);
        // Assert
        result.Should().BeTrue(
            because: "The value {0} respect the institutional email creation rules", inputValue);
    }
    [Fact]
    public void TryCreate_WithIncorrectValue_ReturnsFalse()
    {
        // Arrange
        string inputValue = "correo@noinstitucional.com";
        // Act
        var result = InstitutionalEmailValueObject.TryCreate(inputValue, out var email);
        // Assert
        result.Should().BeFalse(
            because: "The value {0} have a invalid institutional email", inputValue);
    }
    [Fact]
    public void Create_WithCorrectObject_ReturnsTrue()
    {
        // Arrange
        var inputObject = "John.Doe@ucr.ac.cr";
        // Act
        var result = InstitutionalEmailValueObject.Create(inputObject);
        // Assert
        result.Should().NotBeNull(
            because: "The object respect the institutional email creation rules");
    }
}
