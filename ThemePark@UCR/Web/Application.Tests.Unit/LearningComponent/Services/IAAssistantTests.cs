//*******************************************************************//
// Based on LearningSpacerServiceTest Test from "Los chayannes team" //
//*******************************************************************//
using Moq;
using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Services;

public class AIAssistantServiceTests : IClassFixture<AIAssistantTestFixture>
{
    private readonly AIAssistantTestFixture _fixture;

    public AIAssistantServiceTests(AIAssistantTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateValidAIAssistantTrue()
    {
        // Arrange
        var MockAIAssistantRespository = new Mock<IAIAssistantRepository>();
        MockAIAssistantRespository
            .Setup(repository => repository.CreateAIAssistantAsync(_fixture.validAIAssistant))
            .ReturnsAsync(true);

        var aIAssistantService = new AIAssistantService(MockAIAssistantRespository.Object);

        // Act
        var result = await aIAssistantService.CreateAIAssistantsAsync(_fixture.validAIAssistant);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CreateInvalidAIAssistantThrowsArgumentNullException()
    {

        // Arrange
        var MockAIAssistantRespository = new Mock<IAIAssistantRepository>();

        MockAIAssistantRespository
            .Setup(repository => repository.CreateAIAssistantAsync(_fixture.invalidAIAssistant))
            .ReturnsAsync(false);

        var aIAssistantService = new AIAssistantService(MockAIAssistantRespository.Object);

        // Act
        var result = await aIAssistantService.CreateAIAssistantsAsync(_fixture.invalidAIAssistant);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetAIAssistantsReturnsAIAssistants()
    {

        // Arrange
        var MockAIAssistantRespository = new Mock<IAIAssistantRepository>();

        MockAIAssistantRespository
            .Setup(repository => repository.GetAIAssistantAsync())
            .ReturnsAsync(_fixture.aIAssistants);

        var aIAssistantService = new AIAssistantService(MockAIAssistantRespository.Object);

        // Act
        var result = await aIAssistantService.GetAIAssistantsAsync();

        // Assert
        result.Should().BeEquivalentTo(_fixture.aIAssistants);
    }

    [Fact]
    public async Task ModifyAIAssistantReturnTrue()
    {
        // Arrange
        var MockAIAssistantRespository = new Mock<IAIAssistantRepository>();

        MockAIAssistantRespository
            .Setup(repository => repository.ModifyAIAssistantAsync(_fixture.validAIAssistant))
            .ReturnsAsync(true);

        var aIAssistantService = new AIAssistantService(MockAIAssistantRespository.Object);

        // Act
        var result = await aIAssistantService.ModifyAIAssistantAsync(_fixture.validAIAssistant);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ModifyAIAssistantReturnFalse()
    {
        // Arrange
        var MockAIAssistantRespository = new Mock<IAIAssistantRepository>();

        MockAIAssistantRespository
            .Setup(repository => repository.ModifyAIAssistantAsync(_fixture.invalidAIAssistant))
            .ReturnsAsync(false);

        var aIAssistantService = new AIAssistantService(MockAIAssistantRespository.Object);

        // Act
        var result = await aIAssistantService.ModifyAIAssistantAsync(_fixture.invalidAIAssistant);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteAIAssistantReturnTrue()
    {
        // Arrange
        var MockAIAssistantRespository = new Mock<IAIAssistantRepository>();

        MockAIAssistantRespository
            .Setup(repository => repository.DeleteAIAssistantAsync(_fixture.validAIAssistant))
            .ReturnsAsync(true);

        var aIAssistantService = new AIAssistantService(MockAIAssistantRespository.Object);

        // Act
        var result = await aIAssistantService.DeleteAIAssistantAsync(_fixture.validAIAssistant);

        // Assert
        result.Should().BeTrue();
    }
    [Fact]
    public async Task DeleteAIAssistantReturnFalse()
    {
        // Arrange
        var MockAIAssistantRespository = new Mock<IAIAssistantRepository>();

        MockAIAssistantRespository
            .Setup(repository => repository.DeleteAIAssistantAsync(_fixture.invalidAIAssistant))
            .ReturnsAsync(false);

        var aIAssistantService = new AIAssistantService(MockAIAssistantRespository.Object);

        // Act
        var result = await aIAssistantService.DeleteAIAssistantAsync(_fixture.invalidAIAssistant);

        // Assert
        result.Should().BeFalse();
    }


}
