using FluentAssertions;
using Xunit;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Entities;

public class LSTypeTests : IClassFixture<LSTypeValueObjectFixture>
{

    LSTypeValueObjectFixture _fixture;

    public LSTypeTests(LSTypeValueObjectFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void LSTypeConstructor_WithValidParameters_ShouldSetAllPropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LSTypeValueObjectFixture.ActualContext.WithValidParameters);

        // Act
        var lsType = new LSType(
            _fixture.Id.Value,
            _fixture.Name
        );

        // Assert
        lsType.Id.Should().Be(_fixture.Id.Value);
        lsType.Name.Should().Be(_fixture.Name);
    }

    [Fact]
    public void LSTypeConstructor_WithNullId_ShouldThrowArgumentNullException()
    {
        // Arrange
        _fixture.ChangeContext(LSTypeValueObjectFixture.ActualContext.WithNullId);

        // Act
        Action act = () => new LSType(
            _fixture.Id.Value,
            _fixture.Name);

        // Assert
        act.Should().Throw<System.NullReferenceException>()
           .WithMessage("Object reference not set to an instance of an object.");
    }

    [Fact]
    public void LSTypeConstructor_WithNullName_ShouldThrowArgumentNullException()
    {
        // Arrange
        _fixture.ChangeContext(LSTypeValueObjectFixture.ActualContext.WithNullName);

        // Act
        Action act = () => new LSType(_fixture.Id.Value, _fixture.Name);

        // Assert
        act.Should().Throw<ArgumentNullException>()
           .WithMessage("Name cannot be null. (Parameter 'name')");
    }

    [Fact]
    public void LSTypeConstructor_WithEmptyId_ShouldSetIdCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(LSTypeValueObjectFixture.ActualContext.WithEmptyId);

        // Act
        var lsType = new LSType(_fixture.Id.Value, _fixture.Name);

        // Assert
        lsType.Id.Should().Be(_fixture.Id.Value);
    }
}
