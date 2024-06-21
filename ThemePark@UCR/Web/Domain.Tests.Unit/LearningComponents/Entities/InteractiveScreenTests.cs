using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningComponents.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningComponents.Entities;

public class InteractiveScreenTests : IClassFixture<LearningComponentFixture>
{
    private readonly LearningComponentFixture _fixture;

    public InteractiveScreenTests(LearningComponentFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void DefaultInteractiveScreen_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.Default);

        // Act
        var interactiveScreen = _fixture.CreateInteractiveScreen();

        // Assert
        interactiveScreen.LearningComponentAssetId.Should().Be(1);
        interactiveScreen.LearningComponentName.Value.Should().Be("Default");
        interactiveScreen.SizeX.Value.Should().Be(0.0);
        interactiveScreen.SizeY.Value.Should().Be(0.0);
        interactiveScreen.PositionX.Value.Should().Be(0.0);
        interactiveScreen.PositionY.Value.Should().Be(0.0);
        interactiveScreen.PositionZ.Value.Should().Be(0.0);
        interactiveScreen.RotationX.Value.Should().Be(0.0);
        interactiveScreen.RotationY.Value.Should().Be(0.0);
        interactiveScreen.LearningSpaceId.Value.Should().Be(Guid.Empty);
    }

    [Fact]
    public void ValidInteractiveScreen_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.SmallLearningComponent);

        // Act
        var interactiveScreen = _fixture.CreateInteractiveScreen();

        // Assert
        interactiveScreen.LearningComponentAssetId.Should().Be(2);
        interactiveScreen.LearningComponentName.Value.Should().Be("Default");
        interactiveScreen.SizeX.Value.Should().Be(50.0);
        interactiveScreen.SizeY.Value.Should().Be(30.0);
        interactiveScreen.LearningSpaceId.Value.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void InvalidSizeInteractiveScreen_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidSize);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid size.");
    }

    [Fact]
    public void InvalidComponentIDInteractiveScreen_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidComponentID);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid integer Value. (Parameter 'value')");
    }
}