using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Shared.ValueObjects;

public class CoordinateTests
{
    [Theory]
    [InlineData(0.0)]
    [InlineData(100.0)]
    [InlineData(500.125)]
    [InlineData(-100.0)]
    [InlineData(-500.125)]
    public void TryCreate_WithValidValue_ShouldReturnTrue(double value)
    {
        // Arrange

        // Act
        var result = Coordinate.TryCreate(value, out var coordinate);

        // Assert
        result.Should().BeTrue(because: "the coordinate value is valid");
    }

    [Theory]
    [InlineData(null)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void TryCreate_WithInvalidValue_ShouldReturnFalse(double? value)
    {
        // Arrange

        // Act
        var result = Coordinate.TryCreate(value, out var coordinate);

        // Assert
        result.Should().BeFalse(because: "the coordinate value is invalid");
    }

    [Theory]
    [InlineData(0.0)]
    [InlineData(100.0)]
    [InlineData(500.125)]
    [InlineData(-100.0)]
    [InlineData(-500.125)]
    public void Create_WithValidValue_ShouldBeCreated(double value)
    {
        // Arrange

        // Act
        var coordinate = Coordinate.Create(value);

        // Assert
        coordinate.Value.Should().Be(value,
            because: "the coordinate value is valid and the coordinate should be created");
    }

    [Theory]
    [InlineData(null)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void Create_WithInvalidValue_ShouldThrowArgumentException(double? value)
    {
        // Arrange

        // Act
        Action act = () => Coordinate.Create(value);

        // Assert
        act.Should().Throw<ArgumentException>(because: "the coordinate value is invalid");
    }
}
