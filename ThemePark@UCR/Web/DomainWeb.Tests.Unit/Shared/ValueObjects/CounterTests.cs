using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Shared.ValueObjects;

public class CounterTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(47)]
    [InlineData(255)]
    public void TryCreate_WithValidValue_ShouldReturnTrue(byte value)
    {
        // Arrange

        // Act
        var result = Counter.TryCreate(value, out var counter);

        // Assert
        result.Should().BeTrue(because: "the counter value is valid");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(47)]
    [InlineData(255)]
    public void Create_WithValidValue_ShouldBeCreated(byte value)
    {
        // Arrange

        // Act
        var counter = Counter.Create(value);

        // Assert
        counter.Value.Should().Be(value,
            because: "the counter value is valid and the counter should be created");
    }
}
