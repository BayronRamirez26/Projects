using FluentAssertions;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.Entities;

public class UserTest //: IClassFixture<UserValueObjectsFixture>
{/*
    private readonly UserValueObjectsFixture _fixture;

    public UserTest(UserValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }*/

    [Fact]
    public void UserConstructor_WithValidNotNullParameters_ReturnsWithUserId()
    {
        // Arrange
        var inputUserId = Guid.NewGuid();
        var inputPersonId = Guid.NewGuid();
        var inputIsActive = true;
        var inputUserNameMock = new Mock<UserNameValueObject>("JohnDoe");
        var inputPasswordMock = new Mock<PasswordValueObject>("qwerty123");

        // Act
        var user = new UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities.User(
            inputUserId,
            //_fixture.UserNickName,
            //_fixture.UserPasswordHash,
            inputUserNameMock.Object,
            inputPasswordMock.Object,
            inputIsActive,
            inputPersonId);

        // Assert 
        user.UserId.Should().Be(inputUserId,
            because: "the id given to the constructor should match what is returned by the property");
    }
}
