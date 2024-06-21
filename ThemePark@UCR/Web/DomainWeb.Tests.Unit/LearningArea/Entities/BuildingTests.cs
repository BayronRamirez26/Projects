using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningArea.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningArea.Entities;

public class BuildingTests : IClassFixture<BuildingValueObjectsFixture>
{
    private readonly BuildingValueObjectsFixture _fixture;

    public BuildingTests(BuildingValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectBuildingId()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.BuildingId.Should().Be(_fixture.BuildingId,
            because: "the building id given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectUniversityName()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.UniversityName.Should().Be(_fixture.UniversityName,
            because: "the university name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectCampusName()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.CampusName.Should().Be(_fixture.CampusName,
            because: "the campus name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectSiteName()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.SiteName.Should().Be(_fixture.SiteName,
            because: "the site name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectBuildingAcronym()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.BuildingAcronym.Should().Be(_fixture.BuildingAcronym,
            because: "the building acronym given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectBuildingName()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.BuildingName.Should().Be(_fixture.BuildingName,
            because: "the building name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectCenterX()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.CenterX.Should().Be(_fixture.CenterX,
            because: "the center x given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectCenterY()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.CenterY.Should().Be(_fixture.CenterY,
            because: "the center y given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectLength()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.Length.Should().Be(_fixture.Length,
            because: "the length given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectWidth()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.Width.Should().Be(_fixture.Width,
            because: "the width given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectRotation()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.Rotation.Should().Be(_fixture.Rotation,
            because: "the rotation given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectWallsColor()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.WallsColor.Should().Be(_fixture.WallsColor,
            because: "the walls color given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectRoofColor()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.RoofColor.Should().Be(_fixture.RoofColor,
            because: "the roof color given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectHeight()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.Height.Should().Be(_fixture.Height,
            because: "the height given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithValidNotNullParameters_ShouldReturnCorrectLevelCount()
    {
        // Arrange
        _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var building = new Building(
            _fixture.BuildingId, 
            _fixture.UniversityName, 
            _fixture.CampusName, 
            _fixture.SiteName, 
            _fixture.BuildingAcronym, 
            _fixture.BuildingName, 
            _fixture.CenterX, 
            _fixture.CenterY, 
            _fixture.Length, 
            _fixture.Width, 
            _fixture.Rotation, 
            _fixture.WallsColor, 
            _fixture.RoofColor, 
            _fixture.Height, 
            _fixture.LevelCount);

        // Assert
        building.LevelCount.Should().Be(_fixture.LevelCount,
            because: "the level count given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingConstructor_WithInvalidBuildingId_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidBuildingId);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidUniversityName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidUniversityName);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidCampusName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidCampusName);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidSiteName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidSiteName);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidBuildingName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidBuildingName);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidCenterX_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidCenterX);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidCenterY_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidCenterY);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidLength_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidLength);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidWidth_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidWidth);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidRotation_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidRotation);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidWallsColor_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidWallsColor);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidRoofColor_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidRoofColor);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidHeight_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidHeight);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithInvalidLevelCount_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithInvalidLevelCount);

            new Building(
            _fixture.BuildingId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.BuildingName,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Length,
            _fixture.Width,
            _fixture.Rotation,
            _fixture.WallsColor,
            _fixture.RoofColor,
            _fixture.Height,
            _fixture.LevelCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingConstructor_WithNullHeight_ShouldCreateBuilding()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithNullHeight);

            new Building(
                _fixture.BuildingId,
                _fixture.UniversityName,
                _fixture.CampusName,
                _fixture.SiteName,
                _fixture.BuildingAcronym,
                _fixture.BuildingName,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Length,
                _fixture.Width,
                _fixture.Rotation,
                _fixture.WallsColor,
                _fixture.RoofColor,
                _fixture.Height,
                _fixture.LevelCount);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void BuildingConstructor_WithNullLevelCount_ShouldCreateBuilding()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingValueObjectsFixture.Context.WithNullLevelCount);

            new Building(
                _fixture.BuildingId,
                _fixture.UniversityName,
                _fixture.CampusName,
                _fixture.SiteName,
                _fixture.BuildingAcronym,
                _fixture.BuildingName,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Length,
                _fixture.Width,
                _fixture.Rotation,
                _fixture.WallsColor,
                _fixture.RoofColor,
                _fixture.Height,
                _fixture.LevelCount);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }
}
