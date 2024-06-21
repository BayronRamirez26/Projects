using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Entities;
public class LearningSpacesTests : IClassFixture<LearningSpaceValueObjectFixture>
{
    private LearningSpaceValueObjectFixture _fixture;
    public LearningSpacesTests(LearningSpaceValueObjectFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void LearningSpacesConstructor_WithValidParameters_ShouldSetAllPropertiesCorrectly()
    {
        
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithValidParameters);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.LearningSpaceId.Should().Be(_fixture.LearningSpaceId);
        learningSpace.LearningSpaceName.Should().Be(_fixture.LearningSpaceName);
        learningSpace.SizeX.Should().Be(_fixture.SizeX);
        learningSpace.SizeY.Should().Be(_fixture.SizeY);
        learningSpace.SizeZ.Should().Be(_fixture.SizeZ);
        learningSpace.FloorColor.Should().Be(_fixture.FloorColor);
        learningSpace.CeilingColor.Should().Be(_fixture.CeilingColor);
        learningSpace.WallsColor.Should().Be(_fixture.WallsColor);
        learningSpace.LevelId.Should().Be(_fixture.LevelId);
        learningSpace.Type.Should().Be(_fixture.Type);
    }

    [Fact]
    public void LearningSpaceConstructor_WithNullLearningSpaceId_ShouldBeNull()
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithNullLearningSpaceId);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.LearningSpaceId.Should().BeNull();

    }

    [Fact]
    public void LearningSpacesConstructor_WithNullLevelId_ShouldBeNull()
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithNullLevelId);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.LevelId.Should().BeNull();
    }

    [Fact]
    public void LearningSpacesConstructor_WithNullType_ShouldBeNull()
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithNullType);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );


        // Assert
        learningSpace.Type.Should().BeNull();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    public void LearningSpacesConstructor_WithBoundaryCoordinateZeroValue_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithBoundaryCoordinateZeroValue);
        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.SizeX.Value.Should().Be(x);
        learningSpace.SizeY.Value.Should().Be(y);
        learningSpace.SizeZ.Value.Should().Be(z);
    }

    [Theory]
    [InlineData(-10.5, -20.5, -30.5)]
    public void LearningSpaceContructor_WithBoundaryCoordinatesNegative_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithBoundaryCoordinatesNegative);
        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.SizeX.Value.Should().Be(x);
        learningSpace.SizeY.Value.Should().Be(y);
        learningSpace.SizeZ.Value.Should().Be(z);
    }

    [Theory]
    [InlineData(double.MaxValue, double.MinValue, 0)]
    public void LearningSpacesConstructor_WithMaxValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithMaxValues);
        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.SizeX.Value.Should().Be(x);
        learningSpace.SizeY.Value.Should().Be(y);
        learningSpace.SizeZ.Value.Should().Be(z);
    }

    [Theory]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
    public void LearningSpacesConstructor_WithPositiveInfinity_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithPositiveInfinity);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.SizeX.Value.Should().Be(sizeX);
        learningSpace.SizeY.Value.Should().Be(sizeY);
        learningSpace.SizeZ.Value.Should().Be(sizeZ);
    }

    [Theory]
    [InlineData(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity)]
    public void LearningSpacesConstructor_WithNegativeInfinity_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithNegativeInfinity);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.SizeX.Value.Should().Be(sizeX);
        learningSpace.SizeY.Value.Should().Be(sizeY);
        learningSpace.SizeZ.Value.Should().Be(sizeZ);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN, double.NaN)]
    public void LearningSpacesConstructor_WithNaN_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithNaN);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.SizeX.Value.Should().Be(sizeX);
        learningSpace.SizeY.Value.Should().Be(sizeY);
        learningSpace.SizeZ.Value.Should().Be(sizeZ);
    }

    [Theory]
    [InlineData(double.MaxValue * 2, double.MinValue * 2, double.MaxValue * 3)]
    public void LearningSpacesConstructor_WithExtremeValues_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithExtremeSizeValues);

        // Act
        var learningSpace = new LearningSpaces(
            _fixture.LearningSpaceId,
            _fixture.LearningSpaceName,
            _fixture.SizeX,
            _fixture.SizeY,
            _fixture.SizeZ,
            _fixture.FloorColor,
            _fixture.CeilingColor,
            _fixture.WallsColor,
            _fixture.LevelId,
            _fixture.Type
        );

        // Assert
        learningSpace.SizeX.Value.Should().Be(sizeX);
        learningSpace.SizeY.Value.Should().Be(sizeY);
        learningSpace.SizeZ.Value.Should().Be(sizeZ);
    }
    // Additional tests for null parameters, boundary values, and extreme values can be added similarly.

    [Fact]
    public void LearningSpaceContructor_WithDefaultValues_ShouldCreateItCorrectly()
    {
        // Arrenge

        // Act
        LearningSpaces test = new LearningSpaces();

        // Assert
        test.Should().NotBeNull();
    }

    [Fact]
    public void LearningSpaceConstructor_WithIllegalCharactersInShortName_ShouldThrowException()
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithIllegalCharactersInShortName);

        // Act
        Action act = () => {
            new LearningSpaces(
                _fixture.LearningSpaceId,
                ShortName.Create("Hola/"),
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.LevelId,
                _fixture.Type);
        };

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid Short Name.");
    }

    [Fact]
    public void LearningSpaceConstructor_WithLongerShortNameThatAllow_ShoudThrowException()
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithLongerShortNameThatAllow);

        // Act
        Action act = () => {
            new LearningSpaces(
                _fixture.LearningSpaceId,
                ShortName.Create("Holacjdjcjsopcx"),
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.LevelId,
                _fixture.Type);
        };

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid Short Name.");
    }

    [Fact]
    public void LearningSpaceConstructor_WithIllegalCharactersInMediumName_ShouldThrowException()
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithIllegalCharactersInMediumName);

        // Act
        Action act = () => {
            new LearningSpaces(
                _fixture.LearningSpaceId,
                _fixture.LearningSpaceName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                MediumName.Create("@Hola"),
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.LevelId,
                _fixture.Type);
        };

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid medium name.");
    }

    [Fact]
    public void LearningSpaceConstructor_WithLongerMediumNameThatAllow_ShouldThrowException()
    {
        // Arrange
        _fixture.ChangeContext(LearningSpaceValueObjectFixture.actualContext.WithLongerMediumNameThatAllow);

        // Act
        Action act = () => {
            new LearningSpaces(
                _fixture.LearningSpaceId,
                _fixture.LearningSpaceName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                MediumName
                .Create("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyza" +
                "bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefgijk" +
                "lmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"),
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.LevelId,
                _fixture.Type);
        };

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid medium name.");

    }
}

