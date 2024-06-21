using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using Xunit;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.Tests.Unit.LearningSpace.Entities.Wrappers
{
    public class GuidWrapperTests
    {
        [Fact]
        public void Create_WithValidGuid_ReturnsGuidWrapper()
        {
            // Arrange
            var validGuid = Guid.NewGuid();

            // Act
            var guidWrapper = GuidWrapper.Create(validGuid);

            // Assert
            guidWrapper.Should().NotBeNull("because a valid Guid should create a valid GuidWrapper");
            guidWrapper.Value.Should().Be(validGuid, "because the GuidWrapper should hold the same Guid value provided");
        }

        [Fact]
        public void Create_WithEmptyGuid_ReturnsEmptyGuidWrapper()
        {
            // Arrange
            var emptyGuid = Guid.Empty;

            // Act
            var guidWrapper = GuidWrapper.Create(emptyGuid);

            // Assert
            guidWrapper.Value.Should().Be(Guid.Empty, "because the GuidWrapper should hold the same Guid value provided");
        }
    }
}
