using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningArea.Entities;

public class BuildingObjectTests : IClassFixture<BuildingObjectValueObjectsFixture>
{
    private readonly BuildingObjectValueObjectsFixture _fixture;

    public BuildingObjectTests(BuildingObjectValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectObjectId()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.ObjectId.Should().Be(_fixture.ObjectId,
            because: "the object id given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectLevelId()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.LevelId.Should().Be(_fixture.LevelId,
            because: "the level id given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectObjectType()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.ObjectType.Should().Be(_fixture.ObjectType,
            because: "the object type given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectPlane()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Plane.Should().Be(_fixture.Plane,
            because: "the plane given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectObjectName()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.ObjectName.Should().Be(_fixture.ObjectName,
            because: "the object name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectLength()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Length.Should().Be(_fixture.Length,
            because: "the length given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectWidth()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Width.Should().Be(_fixture.Width,
            because: "the width given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectHeight()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Height.Should().Be(_fixture.Height,
            because: "the height given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectCenterX()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.CenterX.Should().Be(_fixture.CenterX,
            because: "the center x given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectCenterY()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.CenterY.Should().Be(_fixture.CenterY,
            because: "the center y given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectRotation()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Rotation.Should().Be(_fixture.Rotation,
            because: "the rotation given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectColorAmount()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.ColorAmount.Should().Be(_fixture.ColorAmount,
            because: "the color amount given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectColor1()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Color1.Should().Be(_fixture.Color1,
            because: "the color 1 given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectColor2()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Color2.Should().Be(_fixture.Color2,
            because: "the color 2 given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectColor3()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Color3.Should().Be(_fixture.Color3,
            because: "the color 3 given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithValidNotNullParameters_ShouldReturnCorrectWallId()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithValidNotNullParameters);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.WallId.Should().Be(_fixture.WallId,
            because: "the wall id given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BuildingObjectConstructor_WithNullColor2_ShouldCreateBuildingObject()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithNullColor2);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithNullColor2_ShouldReturnCorrectColor2()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithNullColor2);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Color2.Should().BeNull();
    }

    [Fact]
    public void BuildingObjectConstructor_WithNullColor3_ShouldCreateBuildingObject()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithNullColor3);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithNullColor3_ShouldReturnCorrectColor3()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithNullColor3);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.Color3.Should().BeNull();
    }

    [Fact]
    public void BuildingObjectConstructor_WithNullWallId_ShouldCreateBuildingObject()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithNullWallId);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithNullWallId_ShouldReturnCorrectWallId()
    {
        // Arrange
        _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithNullWallId);
        
        // Act
        var buildingObject = new BuildingObject(
            _fixture.ObjectId,
            _fixture.LevelId,
            _fixture.ObjectType,
            _fixture.Plane,
            _fixture.ObjectName,
            _fixture.Length,
            _fixture.Width,
            _fixture.Height,
            _fixture.CenterX,
            _fixture.CenterY,
            _fixture.Rotation,
            _fixture.ColorAmount,
            _fixture.Color1,
            _fixture.Color2,
            _fixture.Color3,
            _fixture.WallId);

        // Assert
        buildingObject.WallId.Should().BeNull();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidObjectId_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidObjectId);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidLevelId_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidLevelId);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidObjectType_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidObjectType);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidPlane_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidPlane);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidObjectName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidObjectName);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidLength_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidLength);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidWidth_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidWidth);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidHeight_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidHeight);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidCenterX_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidCenterX);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidCenterY_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidCenterY);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidRotation_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidRotation);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidColor1_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidColor1);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidColor2_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidColor2);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidColor3_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidColor3);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BuildingObjectConstructor_WithInvalidWallId_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BuildingObjectValueObjectsFixture.Context.WithInvalidWallId);

            new BuildingObject(
                _fixture.ObjectId,
                _fixture.LevelId,
                _fixture.ObjectType,
                _fixture.Plane,
                _fixture.ObjectName,
                _fixture.Length,
                _fixture.Width,
                _fixture.Height,
                _fixture.CenterX,
                _fixture.CenterY,
                _fixture.Rotation,
                _fixture.ColorAmount,
                _fixture.Color1,
                _fixture.Color2,
                _fixture.Color3,
                _fixture.WallId);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
