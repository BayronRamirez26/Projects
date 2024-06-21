using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using Xunit;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Entities.Wrappers
{
    public class DoubleWrapperTests
    {
        [Fact]
        public void Create_WithValidDouble_ReturnsDoubleWrapper()
        {
            // Arrange
            var validDouble = 42.0;

            // Act
            var doubleWrapper = DoubleWrapper.Create(validDouble);

            // Assert
            doubleWrapper.Should().NotBeNull("because a valid double should create a valid DoubleWrapper");
            doubleWrapper.Value.Should().Be(validDouble, "because the DoubleWrapper should hold the same double value provided");
        }



        [Fact]
        public void TryCreate_WithValidDouble_ReturnsTrueAndDoubleWrapper()
        {
            // Arrange
            var validDouble = 42.0;

            // Act
            var result = DoubleWrapper.TryCreate(validDouble, out var doubleWrapper);

            // Assert
            result.Should().BeTrue("because the double value is valid");
            doubleWrapper.Should().NotBeNull("because a valid double should create a valid DoubleWrapper");
            doubleWrapper.Value.Should().Be(validDouble, "because the DoubleWrapper should hold the same double value provided");
        }

        [Fact]
        public void TryCreate_WithPositiveInfinity_ReturnsFalseAndInvalidDoubleWrapper()
        {
            // Arrange
            var positiveInfinity = double.PositiveInfinity;

            // Act
            var result = DoubleWrapper.TryCreate(positiveInfinity, out var doubleWrapper);

            // Assert
            result.Should().BeFalse("because the double value is positive infinity");
            doubleWrapper.Should().Be(DoubleWrapper.Invalid, "because the DoubleWrapper should be set to Invalid when the input is positive infinity");
        }
    }
}
