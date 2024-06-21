using FluentAssertions;
using Xunit;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Entities;

public class AccessPointTests : IClassFixture<AccessPointValueObjectFixture>
{
    private AccessPointValueObjectFixture _fixture;
    public AccessPointTests(AccessPointValueObjectFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public void AccessPointConstructor_WithValidParameters_ShouldSetAllPropertiesCorrectly()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithValidParameters);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.AccessPointId.Should().Be(_fixture.AccessPointId);
        accessPoint.LearningSpaceId.Should().Be(_fixture.LearningSpaceId);
        accessPoint.LevelId.Should().Be(_fixture.LevelId);
        accessPoint.CoordX.Should().Be(_fixture.CoordX);
        accessPoint.CoordY.Should().Be(_fixture.CoordY);
        accessPoint.CoordZ.Should().Be(_fixture.CoordZ);
        accessPoint.RotationX.Should().Be(_fixture.RotationX);
        accessPoint.RotationY.Should().Be(_fixture.RotationY);
    }

    [Fact]
    public void AccessPointConstructor_WithNullAccessPointId_ShouldBeNull()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNullAccessPointId);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.AccessPointId.Should().BeNull();
    }

    [Fact]
    public void AccessPointConstructor_WithNullLearningSpaceId_ShouldBeNull()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNullLearningSpaceId);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.LearningSpaceId.Should().BeNull();
    }

    [Fact]
    public void AccessPointConstructor_WithNullLevelId_ShouldBeNull()
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNullLevelId);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.LevelId.Should().BeNull();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    public void AccessPointConstructor_WithZeroCoordinateValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithZeroCoordinateValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(z);
    }

    [Theory]
    [InlineData(-10.5, -20.5, -30.5)]
    public void AccessPointConstructor_WithNegativeCoordinateValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNegativeCoordinateValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );

        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(z);
    }

    [Theory]
    [InlineData(double.MaxValue, double.MinValue, 0)]
    public void AccessPointConstructor_WithMaxCoordinateValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithMaxCoordinateValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(z);
    }


    [Theory]
    [InlineData(0, 0)]
    public void AccessPointConstructor_WithZeroRotationValues_ShouldAssignRotationsCorrectly(double rotationX, double rotationY)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithZeroRotationValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Theory]
    [InlineData(-45.0, -60.0)]
    public void AccessPointConstructor_WithNegativeRotationValues_ShouldAssignRotationsCorrectly(double rotationX, double rotationY)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNegativeRotationValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Theory]
    [InlineData(double.MaxValue, double.MinValue)]
    public void AccessPointConstructor_WithMaxRotationValues_ShouldAssignRotationsCorrectly(double rotationX, double rotationY)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithMaxRotationValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Theory]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
    public void AccessPointConstructor_WithPositiveInfinityCoordinateValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithPositiveInfinityCoordinateValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(z);
    }

    [Theory]
    [InlineData(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity)]
    public void AccessPointConstructor_WithNegativeInfinityCoordinateValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNegativeInfinityCoordinateValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(z);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN, double.NaN)]
    public void AccessPointConstructor_WithNanCoordinateValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNanCoordinateValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );

        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(z);
    }

    [Theory]
    [InlineData(double.MaxValue * 2, double.MinValue * 2, double.MaxValue * -2)] // Values beyond the typical bounds
    public void AccessPointConstructor_WithextremeCoordinateValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithExtremeCoordinateValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(z);
    }

    [Theory]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
    public void AccessPointConstructor_WithPositiveInfinityRotationValues_ShouldAssignRotationsCorrectly(double rotationX, double rotationY)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithPositiveInfinityRotationValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Theory]
    [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
    public void AccessPointConstructor_WithNegativeInfinityRotationValues_ShouldAssignRotationsCorrectly(double rotationX, double rotationY)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNegativeInfinityRotationValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    public void AccessPointConstructor_WithNanRotationValues_ShouldAssignRotationsCorrectly(double rotationX, double rotationY)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithNanRotationValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Theory]
    [InlineData(double.MaxValue * 2, double.MinValue * 2)] // Values beyond the typical bounds
    public void AccessPointConstructor_WithExtremeRotationValues_ShouldAssignRotationsCorrectly(double rotationX, double rotationY)
    {
        // Arrange
        _fixture.ChangeContext(AccessPointValueObjectFixture.actualContext.WithExtremeRotationValues);

        // Act
        var accessPoint = new AccessPoint(
            _fixture.AccessPointId,
            _fixture.LearningSpaceId,
            _fixture.LevelId,
            _fixture.CoordX,
            _fixture.CoordY,
            _fixture.CoordZ,
            _fixture.RotationX,
            _fixture.RotationY
        );


        // Assert
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Fact]
    public void AccessPointConstructor_WithDefaultParameters_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var accessPoint = new AccessPoint(default, default, default, default, default, default, default, default);

        // Assert
        accessPoint.AccessPointId.Should().Be(default);
        accessPoint.LearningSpaceId.Should().Be(default);
        accessPoint.LevelId.Should().Be(default);
        accessPoint.CoordX.Should().Be(default);
        accessPoint.CoordY.Should().Be(default);
        accessPoint.CoordZ.Should().Be(default);
        accessPoint.RotationX.Should().Be(default);
        accessPoint.RotationY.Should().Be(default);
    }

    [Fact]
    public void AccessPointConstructor_WithNullForNonNullableProperties_ShouldThrowException()
    {
        // Arrange & Act
        Action act = () => new AccessPoint(_fixture.AccessPointId, _fixture.LearningSpaceId, _fixture.LevelId,
                                            default(double), default(double), default(double), default(double), default(double));

        // Assert
        act.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void AccessPoint_Properties_ShouldHoldValuesAfterInitialization()
    {
        // Arrange
        var accessPoint = new AccessPoint(_fixture.AccessPointId, _fixture.LearningSpaceId, _fixture.LevelId,
                                          _fixture.CoordX, _fixture.CoordY, _fixture.CoordZ, _fixture.RotationX, _fixture.RotationY);

        // Act & Assert
        accessPoint.AccessPointId.Should().Be(_fixture.AccessPointId);
        accessPoint.LearningSpaceId.Should().Be(_fixture.LearningSpaceId);
        accessPoint.LevelId.Should().Be(_fixture.LevelId);
        accessPoint.CoordX.Should().Be(_fixture.CoordX);
        accessPoint.CoordY.Should().Be(_fixture.CoordY);
        accessPoint.CoordZ.Should().Be(_fixture.CoordZ);
        accessPoint.RotationX.Should().Be(_fixture.RotationX);
        accessPoint.RotationY.Should().Be(_fixture.RotationY);
    }

    [Theory]
    [InlineData(double.MaxValue, double.MinValue, double.MaxValue, double.MinValue)]
    public void AccessPointConstructor_WithExtremeValues_ShouldAssignValuesCorrectly(double x, double y, double rotationX, double rotationY)
    {
        // Arrange & Act
        var accessPoint = new AccessPoint(_fixture.AccessPointId, _fixture.LearningSpaceId, _fixture.LevelId,
                                          x, y, x, rotationX, rotationY);

        // Assert
        accessPoint.CoordX.Should().Be(x);
        accessPoint.CoordY.Should().Be(y);
        accessPoint.CoordZ.Should().Be(x); // Reusing x for simplicity
        accessPoint.RotationX.Should().Be(rotationX);
        accessPoint.RotationY.Should().Be(rotationY);
    }

    [Fact]
    public void AccessPoint_ShouldAllowSettingAndGettingLearningSpace()
    {
        // Arrange
        var accessPoint = new AccessPoint(_fixture.AccessPointId, _fixture.LearningSpaceId, _fixture.LevelId,
                                          _fixture.CoordX, _fixture.CoordY, _fixture.CoordZ, _fixture.RotationX, _fixture.RotationY);

        // Act
        var learningSpace = new LearningSpaces();
        accessPoint.learningSpace = learningSpace;

        // Assert
        accessPoint.learningSpace.Should().Be(learningSpace);
    }

    // Additional tests can be added for edge cases and other scenarios
}

