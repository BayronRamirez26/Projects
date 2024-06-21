/*
using FluentAssertions;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Person.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Tests.Unit.Person.Services;

public class UserServiceTest : IClassFixture<UserListFixture>
{
    private readonly UserListFixture _fixture;

    public UserServiceTest(UserListFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public async Task UserAsync_WhenGivenNonEmptyList_ShouldReturnCorrectUsers()
    {
        //Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock
            .Setup(repository => repository.GetUserCredentialsAsync())
            .ReturnsAsync(_fixture.GetUserList);
        var userService = new UserService(userRepositoryMock.Object);

        //Act
        var results = await userService.GetUserCredentialsAsync();

        //Assert
        results.Should().BeEquivalentTo(_fixture.GetUserList,
            because: "the list of users returned by the service should match the list of users from the repository");

    }
}
*/