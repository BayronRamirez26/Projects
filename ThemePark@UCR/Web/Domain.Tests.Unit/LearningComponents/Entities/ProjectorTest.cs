using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningComponents.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningComponents.Entities;

public class ProjectorTest : IClassFixture<LearningComponentFixture>
{
    private readonly LearningComponentFixture _fixture;

    public ProjectorTest(LearningComponentFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void DefaultProjector_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.Default);

        // Act
        var projector = _fixture.CreateProjector();

        // Assert
        projector.LearningComponentAssetId.Should().Be(1);
        projector.LearningComponentName.Value.Should().Be("Default");
        projector.SizeX.Value.Should().Be(0.0);
        projector.SizeY.Value.Should().Be(0.0);
        projector.PositionX.Value.Should().Be(0.0);
        projector.PositionY.Value.Should().Be(0.0);
        projector.PositionZ.Value.Should().Be(0.0);
        projector.RotationX.Value.Should().Be(0.0);
        projector.RotationY.Value.Should().Be(0.0);
        projector.LearningSpaceId.Value.Should().Be(Guid.Empty);
    }

    [Fact]
    public void ValidProjector_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.SmallLearningComponent);

        // Act
        var projector = _fixture.CreateProjector();

        // Assert
        projector.LearningComponentAssetId.Should().Be(2);
        projector.LearningComponentName.Value.Should().Be("Default");
        projector.SizeX.Value.Should().Be(50.0);
        projector.SizeY.Value.Should().Be(30.0);
        projector.LearningSpaceId.Value.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void InvalidSizeProjector_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidSize);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid size.");
    }

    [Fact]
    public void InvalidComponentIDProjector_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidComponentID);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid integer Value. (Parameter 'value')");
    }
}