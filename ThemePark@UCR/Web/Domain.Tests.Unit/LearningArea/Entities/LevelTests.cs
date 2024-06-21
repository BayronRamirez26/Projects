using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Entities;

public class LevelTests : IClassFixture<LevelValueObjectsFixture>
{
    private readonly LevelValueObjectsFixture _fixture;

    public LevelTests(LevelValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectLevelId()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.LevelId.Should().Be(_fixture.LevelId,
            because: "the level id given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectUniversityName()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.UniversityName.Should().Be(_fixture.UniversityName,
            because: "the university name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectCampusName()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.CampusName.Should().Be(_fixture.CampusName,
            because: "the campus name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectSiteName()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.SiteName.Should().Be(_fixture.SiteName,
            because: "the site name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectBuildingAcronym()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.BuildingAcronym.Should().Be(_fixture.BuildingAcronym,
            because: "the building acronym given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectLevelNumber()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.LevelNumber.Should().Be(_fixture.LevelNumber,
            because: "the level number given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectSizeX()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.SizeX.Should().Be(_fixture.SizeX,
            because: "the size x given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectSizeY()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.SizeY.Should().Be(_fixture.SizeY,
            because: "the size y given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectSizeZ()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.SizeZ.Should().Be(_fixture.SizeZ,
            because: "the size z given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectWallsColor()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.WallsColor.Should().Be(_fixture.WallsColor,
            because: "the walls color given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectFloorColor()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.FloorColor.Should().Be(_fixture.FloorColor,
            because: "the floor color given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectCeilingColor()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.CeilingColor.Should().Be(_fixture.CeilingColor,
            because: "the ceiling color given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithValidNotNullParameters_ShouldReturnCorrectLearningSpaceCount()
    {
        // Arrange
        _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var level = new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);

        // Assert
        level.LearningSpaceCount.Should().Be(_fixture.LearningSpaceCount,
            because: "the learning space count given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void LevelConstructor_WithNullLearningSpaceCount_ShouldCreateLevel()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithNullLearningSpaceCount);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidLevelId_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidLevelId);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidUniversityName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidUniversityName);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidCampusName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidCampusName);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidSiteName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidSiteName);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidBuildingAcronym_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidBuildingAcronym);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidLevelNumber_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidLevelNumber);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidSizeX_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidSizeX);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidSizeY_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidSizeY);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidSizeZ_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidSizeZ);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidWallsColor_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidWallsColor);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidFloorColor_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidFloorColor);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidCeilingColor_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidCeilingColor);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LevelConstructor_WithInvalidLearningSpaceCount_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(LevelValueObjectsFixture.Context.WithInvalidLearningSpaceCount);

            new Level(
            _fixture.LevelId,
            _fixture.UniversityName,
            _fixture.CampusName,
            _fixture.SiteName,
            _fixture.BuildingAcronym,
            _fixture.LevelNumber,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.WallsColor,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.LearningSpaceCount);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
