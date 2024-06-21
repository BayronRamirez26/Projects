using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningComponents.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningComponents.Entities;

public class AIAssistantTests : IClassFixture<LearningComponentFixture>
{
    private readonly LearningComponentFixture _fixture;

    public AIAssistantTests(LearningComponentFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void DefaultAIAssistant_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.Default);

        // Act
        var aIAssistant = _fixture.CreateAIAssistant();

        // Assert
        aIAssistant.LearningComponentAssetId.Should().Be(1);
        aIAssistant.LearningComponentName.Value.Should().Be("Default");
        aIAssistant.SizeX.Value.Should().Be(0.0);
        aIAssistant.SizeY.Value.Should().Be(0.0);
        aIAssistant.PositionX.Value.Should().Be(0.0);
        aIAssistant.PositionY.Value.Should().Be(0.0);
        aIAssistant.PositionZ.Value.Should().Be(0.0);
        aIAssistant.RotationX.Value.Should().Be(0.0);
        aIAssistant.RotationY.Value.Should().Be(0.0);
        aIAssistant.LearningSpaceId.Value.Should().Be(Guid.Empty);
    }

    [Fact]
    public void ValidAIAssistant_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LearningComponentFixture.Context.SmallLearningComponent);

        // Act
        var aIAssistant = _fixture.CreateAIAssistant();

        // Assert
        aIAssistant.LearningComponentAssetId.Should().Be(2);
        aIAssistant.LearningComponentName.Value.Should().Be("Default");
        aIAssistant.SizeX.Value.Should().Be(50.0);
        aIAssistant.SizeY.Value.Should().Be(30.0);
        aIAssistant.LearningSpaceId.Value.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void InvalidSizeAIAssistant_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidSize);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid size.");
    }

    [Fact]
    public void InvalidComponentIDAIAssistant_ShouldThrowArgumentException()
    {
        // Arrange
        Action act = () => _fixture.ChangeContext(LearningComponentFixture.Context.InvalidComponentID);

        // Act & Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid integer Value. (Parameter 'value')");
    }
}