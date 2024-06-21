using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.ValueObjects;

public class BirthDateValueObjectTest
{
    [Fact]
    public void TryCreate_WithCorrectValue_ReturnsTrue()
    {
        // Arrange
        DateOnly inputValue = DateOnly.FromDateTime(DateTime.Now);
        // Act
        var result = BirthDateValueObject.TryCreate(inputValue, out var birthDate);
        // Assert
        result.Should().BeTrue(
            because: "The value {0} respect the datetime creation rules", inputValue);
    }
    [Fact]
    public void TryCreate_WithIncorrectValue_ReturnsFalse()
    {
        // Arrange
        DateOnly inputValue = new DateOnly(9999, 12, 31);
        // Act
        var result = BirthDateValueObject.TryCreate(inputValue, out var birthDate);
        // Assert
        result.Should().BeFalse(
            because: "The value {0} have a invalid datetime", inputValue);
    }
    [Fact]
    public void Create_WithCorrectObject_ReturnsTrue()
    {
        // Arrange
        DateOnly inputObject = DateOnly.FromDateTime(DateTime.Now);
        // Act
        var result = BirthDateValueObject.Create(inputObject);
        // Assert
        result.Should().NotBeNull(
            because: "The object respect the datetime creation rules");
    }
    /*
    [Fact]
    public void Create_WithIncorrectValue_ReturnsFalse()
    {
        // Arrange
        DateTime inputObject = new DateTime(9999, 12, 31);
        // Act
        var result = BirthDateValueObject.Create(inputObject);
        // Assert
        result.Should().Throw<ArgumentException>()
            .WithMessage("Invalid birth date.");
    }*/
}
