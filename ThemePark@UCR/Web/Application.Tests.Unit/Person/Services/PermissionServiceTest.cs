using FluentAssertions;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.Person.Services;

public class PermissionServiceTest : IClassFixture<PermissionListFixture>
{
    private readonly PermissionListFixture _fixture;
    
    public PermissionServiceTest(PermissionListFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public async Task PermissionAsync_WhenGivenNonEmptyList_ShouldReturnCorrectPermissions()
    {
        //Arrange
        var permissionRepositoryMock = new Mock<IPermissionRepository>();
        permissionRepositoryMock
            .Setup(repository => repository.GetAllPermissionsAsync())
            .ReturnsAsync(_fixture.GetPermissionsList);
        var permissionService = new PermissionService(permissionRepositoryMock.Object);

        //Act
        var results = await permissionService.GetAllPermissionsAsync();

        //Assert
        results.Should().BeEquivalentTo(_fixture.GetPermissionsList,
            because: "the list of permissions returned by the service should match the list of permissions from the repository");

    }
}
