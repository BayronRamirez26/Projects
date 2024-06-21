using Moq;
using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningSpace.Services;
public class AccessPointServiceTests : IClassFixture<AccessPointFixture>
{
    private AccessPointFixture _fixture;

    public AccessPointServiceTests(AccessPointFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateAccessPointAsync_ValidInput_ReturnsTrue()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointFixture.actualContext.ValidInput);
        AccessPoint accessPoint = _fixture.returnAccessPoint;

        var _mockAccessPointRepository = new Mock<IAccessPointRepository>();
        _mockAccessPointRepository
            .Setup(repo => repo.CreateAccessPointAsync(accessPoint))
            .ReturnsAsync(true);
        var _accessPointService = new AccessPointService(_mockAccessPointRepository.Object);

        // Act
        var result = await _accessPointService.CreateAccessPointAsync(accessPoint);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CreateAccessPointAsync_NullInput_ReturnsFalse()
    {
        // Arrange
        AccessPoint accessPoint = null;

        var _mockAccessPointRepository = new Mock<IAccessPointRepository>();
        _mockAccessPointRepository
            .Setup(repo => repo.CreateAccessPointAsync(accessPoint))
            .ReturnsAsync(false);
        var _accessPointService = new AccessPointService(_mockAccessPointRepository.Object);

        // Act
        var result = await _accessPointService.CreateAccessPointAsync(accessPoint);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetAccessPointAsync_WhenGivenNoEmptyList_ReturnsAccessPoints()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointFixture.actualContext.WhenGivenNoEmptyList);
        var accessPoints = _fixture.listAccessPoint;

        var _mockAccessPointRepository = new Mock<IAccessPointRepository>();
        _mockAccessPointRepository
            .Setup(repo => repo.GetAccessPointAsync())
            .ReturnsAsync(accessPoints);
        var _accessPointService = new AccessPointService(_mockAccessPointRepository.Object);

        // Act
        var result = await _accessPointService.GetAccessPointAsync();

        // Assert
        result.Should().BeEquivalentTo(accessPoints);
    }

    [Fact]
    public async Task ModifyAccessPointAsync_ValidInput_ReturnsTrue()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointFixture.actualContext.ValidInput);
        AccessPoint accessPoint = _fixture.returnAccessPoint;

        var _mockAccessPointRepository = new Mock<IAccessPointRepository>();
        _mockAccessPointRepository
            .Setup(repo => repo.ModifyAccessPointAsync(accessPoint))
            .ReturnsAsync(true);
        var _accessPointService = new AccessPointService(_mockAccessPointRepository.Object);

        // Act
        var result = await _accessPointService.ModifyAccessPointAsync(accessPoint);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ModifyAccessPointAsync_NullInput_ReturnsFalse()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointFixture.actualContext.NullInput);
        AccessPoint accessPoint = _fixture.returnAccessPoint;

        var _mockAccessPointRepository = new Mock<IAccessPointRepository>();
        _mockAccessPointRepository
            .Setup(repo => repo.ModifyAccessPointAsync(accessPoint))
            .ReturnsAsync(false);
        var _accessPointService = new AccessPointService(_mockAccessPointRepository.Object);

        // Act
        var result = await _accessPointService.ModifyAccessPointAsync(accessPoint);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteAccessPointAsync_ThrowsNotImplementedException()
    {
        // Arrange
        var id = GuidWrapper.Create(Guid.NewGuid());

        var _mockAccessPointRepository = new Mock<IAccessPointRepository>();
        _mockAccessPointRepository
            .Setup(repo => repo.DeleteAccessPointAsync(id))
            .ReturnsAsync(false);
        var _accessPointService = new AccessPointService(_mockAccessPointRepository.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotImplementedException>(() => _accessPointService.DeleteAccessPointAsync(id));
    }
}


