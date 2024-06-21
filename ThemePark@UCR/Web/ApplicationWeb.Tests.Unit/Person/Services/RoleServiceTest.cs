using FluentAssertions;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Tests.Unit.Person.Services;

public class RoleServiceTest : IClassFixture<RoleListFixture>
{
    private readonly RoleListFixture _fixture;

    public RoleServiceTest(RoleListFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public async Task RoleAsync_WhenGivenNonEmptyList_ShouldReturnCorrectRoles()
    {
        //Arrange
        var roleRepositoryMock = new Mock<IRoleRepository>();
        roleRepositoryMock
            .Setup(repository => repository.GetAllRolesAsync())
            .ReturnsAsync(_fixture.GetRolesList);
        var roleService = new RoleService(roleRepositoryMock.Object);

        //Act
        var results = await roleService.GetAllRolesAsync();

        //Assert
        results.Should().BeEquivalentTo(_fixture.GetRolesList,
            because: "the list of permissions returned by the service should match the list of permissions from the repository");

    }
}
