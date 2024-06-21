//*******************************************************************//
// Based on LearningSpacerServiceTest Test from "Los chayannes team" //
//*******************************************************************//
using Moq;
using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Services;

public class InteractiveScreenServiceTests : IClassFixture<InteractiveScreenTestFixture>
{
    private readonly InteractiveScreenTestFixture _fixture;

    public InteractiveScreenServiceTests(InteractiveScreenTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateValidInteractiveScreenTrue()
    {
        // Arrange
        var MockInteractiveScreenRespository = new Mock<IInteractiveScreenRepository>();
        MockInteractiveScreenRespository
            .Setup(repository => repository.CreateInteractiveScreenAsync(_fixture.validInteractiveScreen))
            .ReturnsAsync(true);

        var interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRespository.Object);

        // Act
        var result = await interactiveScreenService.CreateInteractiveScreensAsync(_fixture.validInteractiveScreen);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CreateInvalidInteractiveScreenThrowsArgumentNullException()
    {

        // Arrange
        var MockInteractiveScreenRespository = new Mock<IInteractiveScreenRepository>();

        MockInteractiveScreenRespository
            .Setup(repository => repository.CreateInteractiveScreenAsync(_fixture.invalidInteractiveScreen))
            .ReturnsAsync(false);

        var interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRespository.Object);

        // Act
        var result = await interactiveScreenService.CreateInteractiveScreensAsync(_fixture.invalidInteractiveScreen);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetInteractiveScreensReturnsInteractiveScreens()
    {

        // Arrange
        var MockInteractiveScreenRespository = new Mock<IInteractiveScreenRepository>();

        MockInteractiveScreenRespository
            .Setup(repository => repository.GetInteractiveScreensAsync())
            .ReturnsAsync(_fixture.interactiveScreens);

        var interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRespository.Object);

        // Act
        var result = await interactiveScreenService.GetInteractiveScreensAsync();

        // Assert
        result.Should().BeEquivalentTo(_fixture.interactiveScreens);
    }

    [Fact]
    public async Task ModifyInteractiveScreenReturnTrue()
    {
        // Arrange
        var MockInteractiveScreenRespository = new Mock<IInteractiveScreenRepository>();

        MockInteractiveScreenRespository
            .Setup(repository => repository.ModifyInteractiveScreenAsync(_fixture.validInteractiveScreen))
            .ReturnsAsync(true);

        var interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRespository.Object);

        // Act
        var result = await interactiveScreenService.ModifyInteractiveScreenAsync(_fixture.validInteractiveScreen);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ModifyInteractiveScreenReturnFalse()
    {
        // Arrange
        var MockInteractiveScreenRespository = new Mock<IInteractiveScreenRepository>();

        MockInteractiveScreenRespository
            .Setup(repository => repository.ModifyInteractiveScreenAsync(_fixture.invalidInteractiveScreen))
            .ReturnsAsync(false);

        var interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRespository.Object);

        // Act
        var result = await interactiveScreenService.ModifyInteractiveScreenAsync(_fixture.invalidInteractiveScreen);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteInteractiveScreenReturnTrue()
    {
        // Arrange
        var MockInteractiveScreenRespository = new Mock<IInteractiveScreenRepository>();

        MockInteractiveScreenRespository
            .Setup(repository => repository.DeleteInteractiveScreenAsync(_fixture.validInteractiveScreen))
            .ReturnsAsync(true);

        var interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRespository.Object);

        // Act
        var result = await interactiveScreenService.DeleteInteractiveScreenAsync(_fixture.validInteractiveScreen);

        // Assert
        result.Should().BeTrue();
    }
    [Fact]
    public async Task DeleteInteractiveScreenReturnFalse()
    {
        // Arrange
        var MockInteractiveScreenRespository = new Mock<IInteractiveScreenRepository>();

        MockInteractiveScreenRespository
            .Setup(repository => repository.DeleteInteractiveScreenAsync(_fixture.invalidInteractiveScreen))
            .ReturnsAsync(false);

        var interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRespository.Object);

        // Act
        var result = await interactiveScreenService.DeleteInteractiveScreenAsync(_fixture.invalidInteractiveScreen);

        // Assert
        result.Should().BeFalse();
    }


}
