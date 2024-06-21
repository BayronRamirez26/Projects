using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Fixtures;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Entities
{
    public class TemplateHasComponentsTests : IClassFixture<TemplateHasComponentsFixture>
    {
        private readonly TemplateHasComponentsFixture _fixture;

        public TemplateHasComponentsTests(TemplateHasComponentsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void TemplateHasComponentsConstructor_WithValidParameters_ShouldSetAllPropertiesCorrectly()
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithValidParameters);

            // Act
            var templateHasComponents = new Template_Has_Components(
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.Id.Should().Be(_fixture.Id);
            templateHasComponents.Component_type.Should().Be(_fixture.ComponentType);
            templateHasComponents.Template.Should().Be(_fixture.Template);
            templateHasComponents.SizeX.Should().Be(_fixture.SizeX);
            templateHasComponents.SizeY.Should().Be(_fixture.SizeY);
            templateHasComponents.PositionX.Should().Be(_fixture.PositionX);
            templateHasComponents.PositionY.Should().Be(_fixture.PositionY);
            templateHasComponents.PositionZ.Should().Be(_fixture.PositionZ);
            templateHasComponents.RotationX.Should().Be(_fixture.RotationX);
            templateHasComponents.RotationY.Should().Be(_fixture.RotationY);
        }

        [Fact]
        public void TemplateHasComponentsConstructor_WithNullComponentType_ShouldThrowArgumentNullException()
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithNullComponentType);

            // Act
            var templateHasComponents = new Template_Has_Components
            (
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.Component_type.Should().Be(null, "the ID should match the one given to the constructor, even if it is the default value");
        }

        [Fact]
        public void TemplateHasComponentsConstructor_WithNullTemplate_ShouldThrowArgumentNullException()
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithNullTemplate);

            // Act
            var templateHasComponents = new Template_Has_Components
            (
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.Template.Value.Should().Be(Guid.Empty, "the ID should match the one given to the constructor, even if it is the default value");
        }

        [Fact]
        public void TemplateHasComponentsConstructor_WithDefaultGuid_ShouldSetIdCorrectly()
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithDefaultGuid);

            // Act
            var templateHasComponents = new Template_Has_Components(
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.Id.Value.Should().Be(Guid.Empty, "the ID should match the one given to the constructor, even if it is the default value");
        }

        [Fact]
        public void TemplateHasComponentsConstructor_WithBoundaryValues_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithBoundaryValues);

            // Act
            var templateHasComponents = new Template_Has_Components(
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.SizeX.Value.Should().Be(double.MaxValue, "the sizeX should be set to the maximum value");
            templateHasComponents.SizeY.Value.Should().Be(double.MinValue, "the sizeY should be set to the minimum value");
            templateHasComponents.PositionX.Value.Should().Be(double.PositiveInfinity, "the positionX should be set to positive infinity");
            templateHasComponents.PositionY.Value.Should().Be(double.NegativeInfinity, "the positionY should be set to negative infinity");
            templateHasComponents.PositionZ.Value.Should().Be(double.NaN, "the positionZ should be set to NaN");
            templateHasComponents.RotationX.Value.Should().Be(360.0, "the rotationX should be set to 360 degrees");
            templateHasComponents.RotationY.Value.Should().Be(-360.0, "the rotationY should be set to -360 degrees");
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
        public void TemplateHasComponentsConstructor_WithZeroValues_ShouldSetPropertiesCorrectly(
            double sizeX, double sizeY,
            double positionX, double positionY, double positionZ,
            double rotationX, double rotationY)
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithZeroesValues);

            // Act
            var templateHasComponents = new Template_Has_Components(
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.SizeX.Value.Should().Be(sizeX, $"the sizeX should be set to {sizeX}");
            templateHasComponents.SizeY.Value.Should().Be(sizeY, $"the sizeY should be set to {sizeY}");
            templateHasComponents.PositionX.Value.Should().Be(positionX, $"the positionX should be set to {positionX}");
            templateHasComponents.PositionY.Value.Should().Be(positionY, $"the positionY should be set to {positionY}");
            templateHasComponents.PositionZ.Value.Should().Be(positionZ, $"the positionZ should be set to {positionZ}");
            templateHasComponents.RotationX.Value.Should().Be(rotationX, $"the rotationX should be set to {rotationX}");
            templateHasComponents.RotationY.Value.Should().Be(rotationY, $"the rotationY should be set to {rotationY}");
        }

        [Theory]
        [InlineData(-10.0, -20.0, -30.0, -40.0, -50.0, -60.0, -70.0)]
        public void TemplateHasComponentsConstructor_WithNegativeValues_ShouldSetPropertiesCorrectly(
            double sizeX, double sizeY,
            double positionX, double positionY, double positionZ,
            double rotationX, double rotationY)
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithNegativeValues);

            // Act
            var templateHasComponents = new Template_Has_Components(
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.SizeX.Value.Should().Be(sizeX, $"the sizeX should be set to {sizeX}");
            templateHasComponents.SizeY.Value.Should().Be(sizeY, $"the sizeY should be set to {sizeY}");
            templateHasComponents.PositionX.Value.Should().Be(positionX, $"the positionX should be set to {positionX}");
            templateHasComponents.PositionY.Value.Should().Be(positionY, $"the positionY should be set to {positionY}");
            templateHasComponents.PositionZ.Value.Should().Be(positionZ, $"the positionZ should be set to {positionZ}");
            templateHasComponents.RotationX.Value.Should().Be(rotationX, $"the rotationX should be set to {rotationX}");
            templateHasComponents.RotationY.Value.Should().Be(rotationY, $"the rotationY should be set to {rotationY}");
        }

        [Theory]
        [InlineData(1000.0, 2000.0, 3000.0, 4000.0, 5000.0, 6000.0, 7000.0)]
        public void TemplateHasComponentsConstructor_WithLargeValues_ShouldSetPropertiesCorrectly(
            double sizeX, double sizeY,
            double positionX, double positionY, double positionZ,
            double rotationX, double rotationY)
        {
            // Arrange
            _fixture.ChangeContext(TemplateHasComponentsFixture.actualContext.WithBigValues);

            // Act
            var templateHasComponents = new Template_Has_Components(
                _fixture.Id,
                _fixture.ComponentType,
                _fixture.Template,
                _fixture.SizeX,
                _fixture.SizeY,
                _fixture.PositionX,
                _fixture.PositionY,
                _fixture.PositionZ,
                _fixture.RotationX,
                _fixture.RotationY
            );

            // Assert
            templateHasComponents.SizeX.Value.Should().Be(sizeX, $"the sizeX should be set to {sizeX}");
            templateHasComponents.SizeY.Value.Should().Be(sizeY, $"the sizeY should be set to {sizeY}");
            templateHasComponents.PositionX.Value.Should().Be(positionX, $"the positionX should be set to {positionX}");
            templateHasComponents.PositionY.Value.Should().Be(positionY, $"the positionY should be set to {positionY}");
            templateHasComponents.PositionZ.Value.Should().Be(positionZ, $"the positionZ should be set to {positionZ}");
            templateHasComponents.RotationX.Value.Should().Be(rotationX, $"the rotationX should be set to {rotationX}");
            templateHasComponents.RotationY.Value.Should().Be(rotationY, $"the rotationY should be set to {rotationY}");
        }       
        [Fact]
        public void TemplateHasComponentsDefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Act
            var templateHasComponents = new Template_Has_Components();

            // Assert
            templateHasComponents.Id.Value.Should().NotBe(Guid.Empty, "the ID should be initialized to a new non-empty GUID");
            templateHasComponents.Component_type.Value.Should().Be("Default Name", "the component_type should be initialized to the default name");
            templateHasComponents.Template.Value.Should().NotBe(Guid.Empty, "the template should be initialized to a new non-empty GUID");
            templateHasComponents.SizeX.Value.Should().Be(0.0, "the sizeX should be initialized to 0.0");
            templateHasComponents.SizeY.Value.Should().Be(0.0, "the sizeY should be initialized to 0.0");
            templateHasComponents.PositionX.Value.Should().Be(0.0, "the positionX should be initialized to 0.0");
            templateHasComponents.PositionY.Value.Should().Be(0.0, "the positionY should be initialized to 0.0");
            templateHasComponents.PositionZ.Value.Should().Be(0.0, "the positionZ should be initialized to 0.0");
            templateHasComponents.RotationX.Value.Should().Be(0.0, "the rotationX should be initialized to 0.0");
            templateHasComponents.RotationY.Value.Should().Be(0.0, "the rotationY should be initialized to 0.0");
        }

  

        

    }
}