using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningArea.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningArea.Entities;

public class BOTemplateTests : IClassFixture<BOTemplateValueObjectsFixture>
{
    private readonly BOTemplateValueObjectsFixture _fixture;

    public BOTemplateTests(BOTemplateValueObjectsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectTemplateId()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.TemplateId.Should().Be(_fixture.TemplateId,
            because: "the template id given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectObjectType()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.ObjectType.Should().Be(_fixture.ObjectType,
            because: "the object type given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectPlane()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.Plane.Should().Be(_fixture.Plane,
            because: "the plane given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectObjectName()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.ObjectName.Should().Be(_fixture.ObjectName,
            because: "the object name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectDefaultLength()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.DefaultLength.Should().Be(_fixture.DefaultLength,
            because: "the default length given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectDefaultWidth()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.DefaultWidth.Should().Be(_fixture.DefaultWidth,
            because: "the default width given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectDefaultHeight()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.DefaultHeight.Should().Be(_fixture.DefaultHeight,
            because: "the default height given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectColorAmount()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.ColorAmount.Should().Be(_fixture.ColorAmount,
            because: "the color amount given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectColor1Name()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.Color1Name.Should().Be(_fixture.Color1Name,
            because: "the color 1 name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectDefaultColor1()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.DefaultColor1.Should().Be(_fixture.DefaultColor1,
            because: "the default color 1 given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectColor2Name()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.Color2Name.Should().Be(_fixture.Color2Name,
            because: "the color 2 name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectDefaultColor2()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.DefaultColor2.Should().Be(_fixture.DefaultColor2,
            because: "the default color 2 given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectColor3Name()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.Color3Name.Should().Be(_fixture.Color3Name,
            because: "the color 3 name given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithValidNotNullParameters_ShouldReturnCorrectDefaultColor3()
    {
        // Arrange
        _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithValidNotNullParameters);

        // Act
        var template = new BOTemplate(
            _fixture.TemplateId, 
            _fixture.ObjectType, 
            _fixture.Plane, 
            _fixture.ObjectName, 
            _fixture.DefaultLength,
            _fixture.DefaultWidth, 
            _fixture.DefaultHeight, 
            _fixture.ColorAmount, 
            _fixture.Color1Name, 
            _fixture.DefaultColor1, 
            _fixture.Color2Name, 
            _fixture.DefaultColor2, 
            _fixture.Color3Name, 
            _fixture.DefaultColor3);

        // Assert
        template.DefaultColor3.Should().Be(_fixture.DefaultColor3,
            because: "the default color 3 given to the constructor should be the same as the one returned by the property.");
    }

    [Fact]
    public void BOTemplateConstructor_WithNullColor2Name_ShouldCreateBOTemplate()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithNullColor2Name);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void BOTemplateConstructor_WithNullDefaultColor2_ShouldCreateBOTemplate()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithNullDefaultColor2);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void BOTemplateConstructor_WithNullColor3Name_ShouldCreateBOTemplate()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithNullColor3Name);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };
    }

    [Fact]
    public void BOTemplateConstructor_WithNullDefaultColor3_ShouldCreateBOTemplate()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithNullDefaultColor3);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().NotThrow<Exception>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidTemplateId_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidTemplateId);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidObjectType_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidObjectType);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidPlane_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidPlane);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidObjectName_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidObjectName);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidDefaultLength_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidDefaultLength);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidDefaultWidth_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidDefaultWidth);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidDefaultHeight_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidDefaultHeight);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidColorAmount_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidColorAmount);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidColor1Name_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidColor1Name);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidDefaultColor1_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidDefaultColor1);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidColor2Name_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidColor2Name);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidDefaultColor2_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidDefaultColor2);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidColor3Name_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidColor3Name);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void BOTemplateConstructor_WithInvalidDefaultColor3_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () =>
        {
            _fixture.ChangeContext(BOTemplateValueObjectsFixture.Context.WithInvalidDefaultColor3);

            new BOTemplate(
                _fixture.TemplateId, 
                _fixture.ObjectType, 
                _fixture.Plane, 
                _fixture.ObjectName, 
                _fixture.DefaultLength,
                _fixture.DefaultWidth, 
                _fixture.DefaultHeight, 
                _fixture.ColorAmount, 
                _fixture.Color1Name, 
                _fixture.DefaultColor1, 
                _fixture.Color2Name, 
                _fixture.DefaultColor2, 
                _fixture.Color3Name, 
                _fixture.DefaultColor3);
        };

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
