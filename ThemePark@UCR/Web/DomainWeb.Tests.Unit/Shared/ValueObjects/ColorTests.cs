using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Shared.ValueObjects;

public class ColorTests
{
    [Theory]
    [InlineData("#000000")]
    [InlineData("#FFFFFF")]
    [InlineData("#AA0000")]
    [InlineData("#00BB00")]
    [InlineData("#0000CC")]
    [InlineData("#DD00EE")]
    public void TryCreate_WithValidValue_ShouldReturnTrue(string value)
    {
        // Arrange

        // Act
        var result = Color.TryCreate(value, out var color);

        // Assert
        result.Should().BeTrue(because: "the hex color value is valid");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    [InlineData("#QQWWEE")]
    [InlineData("#1234567")]
    [InlineData("#12345")]
    public void TryCreate_WithInvalidValue_ShouldReturnFalse(string value)
    {
        // Arrange

        // Act
        var result = Color.TryCreate(value, out var color);

        // Assert
        result.Should().BeFalse(because: "the hex color value is invalid");
    }

    [Theory]
    [InlineData("#000000")]
    [InlineData("#FFFFFF")]
    [InlineData("#AA0000")]
    [InlineData("#00BB00")]
    [InlineData("#0000CC")]
    [InlineData("#DD00EE")]
    public void Create_WithValidValue_ShouldBeCreated(string value)
    {
        // Arrange

        // Act
        var color = Color.Create(value);

        // Assert
        color.Value.Should().Be(value,
            because: "the hex color value is valid and the color should be created");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("    ")]
    [InlineData("#QQWWEE")]
    [InlineData("#1234567")]
    [InlineData("#12345")]
    public void Create_WithInvalidValue_ShouldThrowArgumentException(string value)
    {
        // Arrange

        // Act
        Action act = () => Color.Create(value);

        // Assert
        act.Should().Throw<ArgumentException>(because: "the hex color value is invalid").WithMessage("Color value is invalid");
    }
}
