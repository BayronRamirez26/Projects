//*******************************************************************//
// Based on LearningSpacerServiceTest Test from "Los chayannes team" //
//*******************************************************************//
using Moq;
using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Tests.Unit.LearningComponent.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Tests.Unit.LearningComponent.Services;

public class ProjectorServiceTests : IClassFixture<ProjectorTestFixture>
{
    private readonly ProjectorTestFixture _fixture;

    public ProjectorServiceTests(ProjectorTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateValidProjectorTrue()
    {
        // Arrange
        var MockProjectorRespository = new Mock<IProjectorRepository>();
        MockProjectorRespository
            .Setup(repository => repository.CreateProjectorAsync(_fixture.validProjector))
            .ReturnsAsync(true);

        var projectorService = new ProjectorService(MockProjectorRespository.Object);

        // Act
        var result = await projectorService.CreateProjectorsAsync(_fixture.validProjector);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CreateInvalidProjectorThrowsArgumentNullException()
    {

        // Arrange
        var MockProjectorRespository = new Mock<IProjectorRepository>();

        MockProjectorRespository
            .Setup(repository => repository.CreateProjectorAsync(_fixture.invalidProjector))
            .ReturnsAsync(false);

        var projectorService = new ProjectorService(MockProjectorRespository.Object);

        // Act
        var result = await projectorService.CreateProjectorsAsync(_fixture.invalidProjector);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetProjectorsReturnsProjectors()
    {

        // Arrange
        var MockProjectorRespository = new Mock<IProjectorRepository>();

        MockProjectorRespository
            .Setup(repository => repository.GetProjectorsAsync())
            .ReturnsAsync(_fixture.projectors);

        var projectorService = new ProjectorService(MockProjectorRespository.Object);

        // Act
        var result = await projectorService.GetProjectorsAsync();

        // Assert
        result.Should().BeEquivalentTo(_fixture.projectors);
    }

    [Fact]
    public async Task ModifyProjectorReturnTrue()
    {
        // Arrange
        var MockProjectorRespository = new Mock<IProjectorRepository>();

        MockProjectorRespository
            .Setup(repository => repository.ModifyProjectorAsync(_fixture.validProjector))
            .ReturnsAsync(true);

        var projectorService = new ProjectorService(MockProjectorRespository.Object);

        // Act
        var result = await projectorService.ModifyProjectorAsync(_fixture.validProjector);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ModifyProjectorReturnFalse()
    {
        // Arrange
        var MockProjectorRespository = new Mock<IProjectorRepository>();

        MockProjectorRespository
            .Setup(repository => repository.ModifyProjectorAsync(_fixture.invalidProjector))
            .ReturnsAsync(false);

        var projectorService = new ProjectorService(MockProjectorRespository.Object);

        // Act
        var result = await projectorService.ModifyProjectorAsync(_fixture.invalidProjector);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteProjectorReturnTrue()
    {
        // Arrange
        var MockProjectorRespository = new Mock<IProjectorRepository>();

        MockProjectorRespository
            .Setup(repository => repository.DeleteProjectorAsync(_fixture.validProjector))
            .ReturnsAsync(true);

        var projectorService = new ProjectorService(MockProjectorRespository.Object);

        // Act
        var result = await projectorService.DeleteProjectorAsync(_fixture.validProjector);

        // Assert
        result.Should().BeTrue();
    }
    [Fact]
    public async Task DeleteProjectorReturnFalse()
    {
        // Arrange
        var MockProjectorRespository = new Mock<IProjectorRepository>();

        MockProjectorRespository
            .Setup(repository => repository.DeleteProjectorAsync(_fixture.invalidProjector))
            .ReturnsAsync(false);

        var projectorService = new ProjectorService(MockProjectorRespository.Object);

        // Act
        var result = await projectorService.DeleteProjectorAsync(_fixture.invalidProjector);

        // Assert
        result.Should().BeFalse();
    }


}
