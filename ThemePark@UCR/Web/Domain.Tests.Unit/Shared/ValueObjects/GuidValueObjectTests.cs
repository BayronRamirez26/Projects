using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Shared.ValueObjects;

public class GuidValueObjectTests
{
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    [InlineData("11111111-1111-1111-1111-111111111111")]
    [InlineData("22222222-2222-2222-2222-222222222222")]
    [InlineData("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")]
    [InlineData("ffffffff-ffff-ffff-ffff-ffffffffffff")]
    public void TryCreate_WithValidValue_ShouldReturnTrue(string value)
    {
        // Arrange

        // Act
        var result = GuidValueObject.TryCreate(Guid.Parse(value), out var guidValueObject);

        // Assert
        result.Should().BeTrue(because: "the guid value is valid");
    }

    [Theory]
    [InlineData(null)]
    public void TryCreate_WithInvalidValue_ShouldReturnFalse(Guid? value)
    {
        // Arrange

        // Act
        var result = GuidValueObject.TryCreate(value, out var guidValueObject);

        // Assert
        result.Should().BeFalse(because: "the guid value is invalid");
    }

    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    [InlineData("11111111-1111-1111-1111-111111111111")]
    [InlineData("22222222-2222-2222-2222-222222222222")]
    [InlineData("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")]
    [InlineData("ffffffff-ffff-ffff-ffff-ffffffffffff")]
    public void Create_WithValidValue_ShouldBeCreated(string value)
    {
        // Arrange

        // Act
        var guidValueObject = GuidValueObject.Create(Guid.Parse(value));

        // Assert
        guidValueObject.Value.Should().Be(Guid.Parse(value),
            because: "the guid value is valid and the guid should be created");
    }

    [Theory]
    [InlineData(null)]
    public void Create_WithInvalidValue_ShouldThrowArgumentException(Guid? value)
    {
        // Arrange

        // Act
        Action act = () => GuidValueObject.Create(value);

        // Assert
        act.Should().Throw<ArgumentException>(because: "the guid value is invalid");
    }
}
