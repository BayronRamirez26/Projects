using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningSpace.Entities
{
    public class TemplatesTests : IClassFixture<TemplateValueObjectFixture>
    {
        private TemplateValueObjectFixture _fixture;

        public TemplatesTests(TemplateValueObjectFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void TemplatesConstructor_WithValidParameters_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithValidParameters);

            // Act
            var template = new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            template.Id.Should().Be(_fixture.Id);
            template.TemplateName.Should().Be(_fixture.TemplateName);
            template.SizeX.Should().Be(_fixture.SizeX);
            template.SizeY.Should().Be(_fixture.SizeY);
            template.SizeZ.Should().Be(_fixture.SizeZ);
            template.FloorColor.Should().Be(_fixture.FloorColor);
            template.CeilingColor.Should().Be(_fixture.CeilingColor);
            template.WallsColor.Should().Be(_fixture.WallsColor);
            template.Type.Should().Be(_fixture.Type);
        }

        [Theory]
        [InlineData(-10.5, -20.5, -30.5)]
        public void TemplatesConstructor_WithBoundaryCoordinatesNegative_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithBoundaryCoordinatesNegative);

            // Act
            var template = new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            template.SizeX.Value.Should().Be(x);
            template.SizeY.Value.Should().Be(y);
            template.SizeZ.Value.Should().Be(z);
        }

        [Theory]
        [InlineData(double.MaxValue, double.MinValue, 0)]
        public void TemplatesConstructor_WithMaxValues_ShouldAssignCoordinatesCorrectly(double x, double y, double z)
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithMaxValues);

            // Act
            var template = new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            template.SizeX.Value.Should().Be(x);
            template.SizeY.Value.Should().Be(y);
            template.SizeZ.Value.Should().Be(z);
        }

        [Theory]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
        public void TemplatesConstructor_WithPositiveInfinity_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithPositiveInfinity);

            // Act
            var template = new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            template.SizeX.Value.Should().Be(sizeX);
            template.SizeY.Value.Should().Be(sizeY);
            template.SizeZ.Value.Should().Be(sizeZ);
        }

        [Theory]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity)]
        public void TemplatesConstructor_WithNegativeInfinity_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithNegativeInfinity);

            // Act
            var template = new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            template.SizeX.Value.Should().Be(sizeX);
            template.SizeY.Value.Should().Be(sizeY);
            template.SizeZ.Value.Should().Be(sizeZ);
        }

        [Theory]
        [InlineData(double.NaN, double.NaN, double.NaN)]
        public void TemplatesConstructor_WithNaN_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithNaN);

            // Act
            var template = new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            template.SizeX.Value.Should().Be(sizeX);
            template.SizeY.Value.Should().Be(sizeY);
            template.SizeZ.Value.Should().Be(sizeZ);
        }

        [Theory]
        [InlineData(double.MaxValue * 2, double.MinValue * 2, double.MaxValue * 3)]
        public void TemplatesConstructor_WithExtremeValues_ShouldAssignSizesCorrectly(double sizeX, double sizeY, double sizeZ)
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithExtremeSizeValues);

            // Act
            var template = new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            template.SizeX.Value.Should().Be(sizeX);
            template.SizeY.Value.Should().Be(sizeY);
            template.SizeZ.Value.Should().Be(sizeZ);
        }

        [Fact]
        public void TemplatesConstructor_WithNullName_ShouldNotThrowArgumentNullException()
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithNullName);

            // Act
            Action act = () => new Templates(
                _fixture.Id,
                null, // Null Template Name
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void TemplatesConstructor_WithNullFloorColor_ShouldNotThrowArgumentNullException()
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithNullFloorColor);

            // Act
            Action act = () => new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                null, // Null Floor Color
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void TemplatesConstructor_WithNullCeilingColor_ShouldNotThrowArgumentNullException()
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithNullCeilingColor);

            // Act
            Action act = () => new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                null, // Null Ceiling Color
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void TemplatesConstructor_WithNullWallsColor_ShouldNotThrowArgumentNullException()
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithNullWallsColor);

            // Act
            Action act = () => new Templates(
                _fixture.Id,
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                null, // Null Walls Color
                _fixture.Type);

            // Assert
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void TemplatesConstructor_WithInvalidGuid_ShouldNotThrowArgumentException()
        {
            // Arrange
            _fixture.ChangeContext(TemplateValueObjectFixture.actualContext.WithInvalidGuid);

            // Act
            Action act = () => new Templates(
                Guid.Empty, // Invalid Guid
                _fixture.TemplateName,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.SizeZ,
                _fixture.FloorColor,
                _fixture.CeilingColor,
                _fixture.WallsColor,
                _fixture.Type);

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }
        // Additional tests for null parameters, boundary values, and extreme values can be added similarly.
    }
}
