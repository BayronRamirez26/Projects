using FluentAssertions;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Person.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Person.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.Person.Entities;

public class PermissionTest : IClassFixture<PermissionValueObjectsFixture>
{
    private readonly PermissionValueObjectsFixture _fixture;

    public PermissionTest(PermissionValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void PermissionConstructor_WithValidNotNullParameters_ReturnsWithPermissionId()
    {
        // Arrange
        var inputPermissionId = Guid.NewGuid();

        // Act
        var permission = new Permission(
            inputPermissionId,
            _fixture.PermissionDescription);

        // Assert 
        permission.PermissionId.Should().Be(inputPermissionId,
            because: "the id given to the constructor should match what is returned by the property");
    }
    [Fact]
    public void PermissionConstructor_WithValidNotNullParameters_ReturnsWithPermissionDescription()
    {
        // Arrange
        var inputPermissionId = Guid.NewGuid();

        // Act
        var permission = new Permission(
            inputPermissionId,
            _fixture.PermissionDescription);

        // Assert 
        permission.PermissionDescription.Should().Be(_fixture.PermissionDescription,
            because: "the permission description given to the constructor should match what is returned by the property");
    }
}
