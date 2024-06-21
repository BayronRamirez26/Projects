using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Shared.ValueObjects;

public class SizeTests
{
    [Theory]
    [InlineData(0.0)]
    [InlineData(100.0)]
    [InlineData(500.125)]
    [InlineData(1000.0)]
    [InlineData(10000.575)]
    public void TryCreate_WithValidValue_ShouldReturnTrue(double value)
    {
        // Arrange

        // Act
        var result = Size.TryCreate(value, out var size);

        // Assert
        result.Should().BeTrue(because: "the size value is valid");
    }

    [Theory]
    [InlineData(null)]
    [InlineData(double.NaN)]
    [InlineData(-1.0)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void TryCreate_WithInvalidValue_ShouldReturnFalse(double? value)
    {
        // Arrange

        // Act
        var result = Size.TryCreate(value, out var size);

        // Assert
        result.Should().BeFalse(because: "the size value is invalid");
    }

    [Theory]
    [InlineData(0.0)]
    [InlineData(100.0)]
    [InlineData(500.125)]
    [InlineData(1000.0)]
    [InlineData(10000.575)]
    public void Create_WithValidValue_ShouldBeCreated(double value)
    {
        // Arrange

        // Act
        var size = Size.Create(value);

        // Assert
        size.Value.Should().Be(value,
            because: "the size value is valid and the size should be created");
    }

    [Theory]
    [InlineData(null)]
    [InlineData(double.NaN)]
    [InlineData(-1.0)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void Create_WithInvalidValue_ShouldThrowArgumentException(double? value)
    {
        // Arrange

        // Act
        Action act = () => Size.Create(value);

        // Assert
        act.Should().Throw<ArgumentException>(because: "the size value is invalid");
    }
}
