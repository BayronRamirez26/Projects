using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Shared.ValueObjects;

public class AngleTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(47.9)]
    [InlineData(180)]
    [InlineData(233.5)]
    [InlineData(360)]
    public void TryCreate_WithValidValue_ShouldReturnTrue(double value)
    {
        // Arrange

        // Act
        var result = Angle.TryCreate(value, out var angle);

        // Assert
        result.Should().BeTrue(because: "the angle value is valid");
    }

    [Theory]
    [InlineData(double.NaN)]
    [InlineData(-1)]
    [InlineData(361)]
    [InlineData(1000)]
    public void TryCreate_WithInvalidValue_ShouldReturnFalse(double value)
    {
        // Arrange

        // Act
        var result = Angle.TryCreate(value, out var angle);

        // Assert
        result.Should().BeFalse(because: "the angle value is invalid");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(47.9)]
    [InlineData(180)]
    [InlineData(233.5)]
    [InlineData(360)]
    public void Create_WithValidValue_ShouldBeCreated(double value)
    {
        // Arrange

        // Act
        var angle = Angle.Create(value);

        // Assert
        angle.Value.Should().Be(value,
            because: "the angle value is valid and the angle should be created");
    }

    [Theory]
    [InlineData(double.NaN)]
    [InlineData(-1)]
    [InlineData(361)]
    [InlineData(1000)]
    public void Create_WithInvalidValue_ShouldThrowArgumentException(double value)
    {
        // Arrange

        // Act
        Action act = () => Angle.Create(value);

        // Assert
        act.Should().Throw<ArgumentException>(because: "the angle value is invalid");
    }
}
