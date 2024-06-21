using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningComponents.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningComponents.Entities;

public class WhiteboardTests : IClassFixture<LearningComponentFixture>
{
    private readonly LearningComponentFixture _fixture;

    public WhiteboardTests(LearningComponentFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void DefaultWhiteboard_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.Default);

        // Act
        var whiteboard = _fixture.CreateWhiteboard();

        // Assert
        whiteboard.LearningComponentAssetId.Should().Be(1);
        whiteboard.LearningComponentName.Value.Should().Be("Default");
        whiteboard.SizeX.Value.Should().Be(0.0);
        whiteboard.SizeY.Value.Should().Be(0.0);
        whiteboard.PositionX.Value.Should().Be(0.0);
        whiteboard.PositionY.Value.Should().Be(0.0);
        whiteboard.PositionZ.Value.Should().Be(0.0);
        whiteboard.RotationX.Value.Should().Be(0.0);
        whiteboard.RotationY.Value.Should().Be(0.0);
        whiteboard.LearningSpaceId.Value.Should().Be(Guid.Empty);
    }

    [Fact]
    public void SmallWhiteboard_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.SmallLearningComponent);

        // Act
        var whiteboard = _fixture.CreateWhiteboard();

        // Assert
        whiteboard.LearningComponentAssetId.Should().Be(2);
        whiteboard.LearningComponentName.Value.Should().Be("Default");
        whiteboard.SizeX.Value.Should().Be(50.0);
        whiteboard.SizeY.Value.Should().Be(30.0);
        whiteboard.LearningSpaceId.Value.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void InvalidSizeWhiteboard_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidSize);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid size.");
    }

    [Fact]
    public void InvalidComponentIDWhiteboard_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidComponentID);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid integer Value. (Parameter 'value')");
    }
}