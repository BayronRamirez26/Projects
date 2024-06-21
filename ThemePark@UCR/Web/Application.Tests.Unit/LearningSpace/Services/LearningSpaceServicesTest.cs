using FluentAssertions;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningSpace.Services;

public class LearningSpaceServiceTests : IClassFixture<LearningSpaceListFixture>
{
    private readonly LearningSpaceListFixture _fixture;

    public LearningSpaceServiceTests(LearningSpaceListFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateLearningSpaceAsync_ValidInput_ReturnsTrue()
    {
        // Arrange
        var MockLearningSpaceRepository = new Mock<ILearningSpaceRepository>();
        MockLearningSpaceRepository
            .Setup(repository => repository.CreateLearningSpaceAsync(_fixture.LearningSpacesValid))
            .ReturnsAsync(true);

        var learningSpaceService = new LearningSpaceService(MockLearningSpaceRepository.Object);


        // Act
        var result = await learningSpaceService.CreateLearningSpaceAsync(_fixture.LearningSpacesValid);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CreateLearningSpaceAsync_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        var MockLearningSpaceRepository = new Mock<ILearningSpaceRepository>();
        MockLearningSpaceRepository
            .Setup(repository => repository.CreateLearningSpaceAsync(_fixture.LearningSpacesInvalid))
            .ReturnsAsync(false);

        var learningSpaceService = new LearningSpaceService(MockLearningSpaceRepository.Object);


        // Act
        var result = await learningSpaceService.CreateLearningSpaceAsync(_fixture.LearningSpacesInvalid);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetLearningSpaceAsync_ReturnsLearningSpaces()
    {
        // Arrange
        var MockLearningSpaceRepository = new Mock<ILearningSpaceRepository>();
        MockLearningSpaceRepository
            .Setup(repository => repository.GetLearningSpaceAsync())
            .ReturnsAsync(_fixture.LearningSpacesList);

        var learningSpaceService = new LearningSpaceService(MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetLearningSpaceAsync();

        // Assert
        result.Should().BeEquivalentTo(_fixture.LearningSpacesList);
    }

    [Fact]
    public async Task ModifyLearningSpaceAsync_ValidInput_ReturnsTrue()
    {
        // Arrange
        var mockLearningSpaceRepository = new Mock<ILearningSpaceRepository>();

        mockLearningSpaceRepository
            .Setup(repo => repo.ModifyLearningSpaceAsync(_fixture.LearningSpacesValid))
            .ReturnsAsync(true);

        var learningSpaceService = new LearningSpaceService(mockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.ModifyLearningSpaceAsync(_fixture.LearningSpacesValid);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteLearningSpaceAsync_ValidId_ReturnsTrue()
    {
        // Arrange
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.DeleteLearningSpaceAsync(_fixture.LearningSpacesList.First().LearningSpaceId))
            .ReturnsAsync(true);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.DeleteLearningSpaceAsync(_fixture.LearningSpacesList.First().LearningSpaceId);

        // Assert
        Assert.True(result);
    }


    [Fact]
    public async Task GetLearningSpaceFromIdAsync_ValidId_ReturnsLearningSpace()
    {
        // Arrange
        var learningSpace = _fixture.LearningSpacesValid;
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.GetLearningSpaceFromIdAsync(_fixture.LearningSpacesValid.LearningSpaceId))
            .ReturnsAsync(learningSpace);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetLearningSpaceFromIdAsync(_fixture.LearningSpacesValid.LearningSpaceId);

        // Assert
        result.Should().BeEquivalentTo(learningSpace);
    }

    [Fact]
    public async Task GetLSTypeFromIdAsync_ValidId_ReturnsLSType()
    {
        // Arrange
        var id = _fixture.LSTypeguid;
        var lsType = _fixture.LSType;
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.GetLSTypeFromIdAsync(id))
            .ReturnsAsync(lsType);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetLSTypeFromIdAsync(id);

        // Assert
        result.Should().BeEquivalentTo(lsType);
    }



    [Fact]
    public async Task GetLearningSpacesByLSTypeIdAsync_ValidId_ReturnsLearningSpaces()
    {
        // Arrange
        var learningSpaces = _fixture.LearningSpacesList;
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.GetLearningSpacesByLSTypeIdAsync(_fixture.LearningSpacesValid.LearningSpaceId))
            .ReturnsAsync(learningSpaces);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetLearningSpacesByLSTypeIdAsync(_fixture.LearningSpacesValid.LearningSpaceId);

        // Assert
        result.Should().BeEquivalentTo(learningSpaces);
    }


    [Fact]
    public async Task GetProjectorsOfALearningSpacesAsync_ValidId_ReturnsProjectors()
    {
        // Arrange
        var projectors = _fixture.ProjectorsList;
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.GetProjectorsOfALearningSpacesAsync(_fixture.ProjectorsList.First().LearningSpaceId))
            .ReturnsAsync(projectors);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetProjectorsOfALearningSpacesAsync(_fixture.ProjectorsList.First().LearningSpaceId);

        // Assert
        result.Should().BeEquivalentTo(projectors);
    }


    [Fact]
    public async Task GetWhiteboardOfALearningSpacesAsync_ValidId_ReturnsWhiteboards()
    {
        // Arrange
        var whiteboards = _fixture.WhiteboardsList;
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.GetWhiteboardOfALearningSpacesAsync(_fixture.WhiteboardsList.First().LearningSpaceId))
            .ReturnsAsync(whiteboards);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetWhiteboardOfALearningSpacesAsync(_fixture.WhiteboardsList.First().LearningSpaceId);

        // Assert
        result.Should().BeEquivalentTo(whiteboards);
    }


    [Fact]
    public async Task GetInteractiveScreenOfALearningSpacesAsync_ValidId_ReturnsInteractiveScreens()
    {
        // Arrange
        var interactiveScreens = _fixture.InteractiveScreensList;
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.GetInteractiveScreenOfALearningSpacesAsync(_fixture.InteractiveScreensList.First().LearningSpaceId))
            .ReturnsAsync(interactiveScreens);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetInteractiveScreenOfALearningSpacesAsync(_fixture.InteractiveScreensList.First().LearningSpaceId);

        // Assert
        result.Should().BeEquivalentTo(interactiveScreens);
    }


    [Fact]
    public async Task GetAccessPointsOfALearningSpacesAsync_ValidId_ReturnsAccessPoints()
    {
        // Arrange
        var accessPoints = _fixture.AccessPointsList;
        _fixture.MockLearningSpaceRepository
            .Setup(repo => repo.GetAccessPointsOfALearningSpacesAsync(_fixture.AccessPointsList.First().LearningSpaceId))
            .ReturnsAsync(accessPoints);

        var learningSpaceService = new LearningSpaceService(_fixture.MockLearningSpaceRepository.Object);

        // Act
        var result = await learningSpaceService.GetAccessPointsOfALearningSpacesAsync(_fixture.AccessPointsList.First().LearningSpaceId);

        // Assert
        result.Should().BeEquivalentTo(accessPoints);
    }

}

