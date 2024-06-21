//*******************************************************************//
// Based on LearningSpacerServiceTest Test from "Los chayannes team" //
//*******************************************************************//
using Moq;
using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Services;

public class WhiteboardServiceTests : IClassFixture<WhiteboardTestFixture>
{
    private readonly WhiteboardTestFixture _fixture;

    public WhiteboardServiceTests(WhiteboardTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateValidWhiteboardTrue()
    {
        // Arrange
        var MockWhiteboardRespository = new Mock<IWhiteboardRepository>();
        MockWhiteboardRespository
            .Setup(repository => repository.CreateWhiteboardAsync(_fixture.validWhiteboard))
            .ReturnsAsync(true);

        var whiteboardService = new WhiteboardService(MockWhiteboardRespository.Object);

        // Act
        var result = await whiteboardService.CreateWhiteboardsAsync(_fixture.validWhiteboard);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CreateInvalidWhiteboardThrowsArgumentNullException()
    {

        // Arrange
        var MockWhiteboardRespository = new Mock<IWhiteboardRepository>();

        MockWhiteboardRespository
            .Setup(repository => repository.CreateWhiteboardAsync(_fixture.invalidWhiteboard))
            .ReturnsAsync(false);

        var whiteboardService = new WhiteboardService(MockWhiteboardRespository.Object);

        // Act
        var result = await whiteboardService.CreateWhiteboardsAsync(_fixture.invalidWhiteboard);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetWhiteboardsReturnsWhiteboards()
    {

        // Arrange
        var MockWhiteboardRespository = new Mock<IWhiteboardRepository>();

        MockWhiteboardRespository
            .Setup(repository => repository.GetWhiteboardsAsync())
            .ReturnsAsync(_fixture.whiteboards);

        var whiteboardService = new WhiteboardService(MockWhiteboardRespository.Object);

        // Act
        var result = await whiteboardService.GetWhiteboardsAsync();

        // Assert
        result.Should().BeEquivalentTo(_fixture.whiteboards);
    }

    [Fact]
    public async Task ModifyWhiteboardReturnTrue()
    {
        // Arrange
        var MockWhiteboardRespository = new Mock<IWhiteboardRepository>();

        MockWhiteboardRespository
            .Setup(repository => repository.ModifyWhiteboardAsync(_fixture.validWhiteboard))
            .ReturnsAsync(true);

        var whiteboardService = new WhiteboardService(MockWhiteboardRespository.Object);

        // Act
        var result = await whiteboardService.ModifyWhiteboardAsync(_fixture.validWhiteboard);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ModifyWhiteboardReturnFalse()
    {
        // Arrange
        var MockWhiteboardRespository = new Mock<IWhiteboardRepository>();

        MockWhiteboardRespository
            .Setup(repository => repository.ModifyWhiteboardAsync(_fixture.invalidWhiteboard))
            .ReturnsAsync(false);

        var whiteboardService = new WhiteboardService(MockWhiteboardRespository.Object);

        // Act
        var result = await whiteboardService.ModifyWhiteboardAsync(_fixture.invalidWhiteboard);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteWhiteboardReturnTrue()
    {
        // Arrange
        var MockWhiteboardRespository = new Mock<IWhiteboardRepository>();

        MockWhiteboardRespository
            .Setup(repository => repository.DeleteWhiteboardAsync(_fixture.validWhiteboard))
            .ReturnsAsync(true);

        var whiteboardService = new WhiteboardService(MockWhiteboardRespository.Object);

        // Act
        var result = await whiteboardService.DeleteWhiteboardAsync(_fixture.validWhiteboard);

        // Assert
        result.Should().BeTrue();
    }
    [Fact]
    public async Task DeleteWhiteboardReturnFalse()
    {
        // Arrange
        var MockWhiteboardRespository = new Mock<IWhiteboardRepository>();

        MockWhiteboardRespository
            .Setup(repository => repository.DeleteWhiteboardAsync(_fixture.invalidWhiteboard))
            .ReturnsAsync(false);

        var whiteboardService = new WhiteboardService(MockWhiteboardRespository.Object);

        // Act
        var result = await whiteboardService.DeleteWhiteboardAsync(_fixture.invalidWhiteboard);

        // Assert
        result.Should().BeFalse();
    }


}
