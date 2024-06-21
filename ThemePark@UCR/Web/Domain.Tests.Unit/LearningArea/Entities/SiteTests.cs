using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Entities;

public class SiteTests : IClassFixture<SiteValueObjectsFixture>
{
    private readonly SiteValueObjectsFixture _fixture;

    public SiteTests(SiteValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void SiteConstructor_WithValidParameters_ShouldReturnCorrectUniversityName()
    {
        // Arrange
        _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithValidParameters);
        
        // Act
        var site = new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);

        // Assert
        site.UniversityName.Should().Be(_fixture.UniversityName,
            because: "the university name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void SiteConstructor_WithValidParameters_ShouldReturnCorrectCampusName()
    {
        // Arrange
        _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithValidParameters);

        // Act
        var site = new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);

        // Assert
        site.CampusName.Should().Be(_fixture.CampusName,
            because: "the campus name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void SiteConstructor_WithValidParameters_ShouldReturnCorrectSiteName()
    {
        // Arrange
        _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithValidParameters);
        
        // Act
        var site = new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);

        // Assert
        site.SiteName.Should().Be(_fixture.SiteName,
            because: "the site name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void SiteConstructor_WithValidParameters_ShouldReturnCorrectSizeX()
    {
        // Arrange
        _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithValidParameters);
        
        // Act
        var site = new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);

        // Assert
        site.SizeX.Should().Be(_fixture.SizeX,
            because: "the size X given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void SiteConstructor_WithValidParameters_ShouldReturnCorrectSizeY()
    {
        // Arrange
        _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithValidParameters);
        
        // Act
        var site = new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);

        // Assert
        site.SizeY.Should().Be(_fixture.SizeY,
            because: "the size Y given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void SiteConstructor_WithNullUniversityName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithInvalidUniversityName);

            new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void SiteConstructor_WithNullCampusName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithInvalidCampusName);

            new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void SiteConstructor_WithNullSiteName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithInvalidSiteName);

            new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void SiteConstructor_WithInvalidSizeX_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithInvalidSizeX);

            new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void SiteConstructor_WithInvalidSizeY_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(SiteValueObjectsFixture.Context.WithInvalidSizeY);

            new Site(
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.SizeX,
            _fixture.SizeY);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
