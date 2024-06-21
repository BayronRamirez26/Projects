using FluentAssertions;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.Person.Entities;

public class RoleTest : IClassFixture<RoleValueObjectsFixture>
{
    private readonly RoleValueObjectsFixture _fixture;

    public RoleTest(RoleValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void RoleConstructor_WithValidNotNullParameters_ReturnsWithRoleId()
    {
        // Arrange
        var inputRoleId = Guid.NewGuid();

        // Act
        var role = new Role(
            inputRoleId,
            _fixture.RoleName);

        // Assert 
        role.RoleId.Should().Be(inputRoleId,
            because: "the id given to the constructor should match what is returned by the property");
    }
    [Fact]
    public void RoleConstructor_WithValidNotNullParameters_ReturnsWithRoleName()
    {
        // Arrange
        var inputRoleId = Guid.NewGuid();

        // Act
        var role = new Role(
            inputRoleId,
            _fixture.RoleName);

        // Assert 
        role.RoleName.Should().Be(_fixture.RoleName,
            because: "the role name given to the constructor should match what is returned by the property");
    }
}
