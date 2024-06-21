using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.RelationName.ValueObjects
{
    public class MediumNameTests
    {
        [Fact]
        public void TryCreate_WithMoreCharacters_ReturnsTrue()
        {
            //Arrange
            var inputValue = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\r\n";

            // Act
            var result = MediumName.TryCreate(inputValue, out var name);
            // Assert
            result.Should().BeFalse(
                because: "The 127 limit should not be overflowed", inputValue);
        }

        [Fact]
        public void TryCreate_WithIllegalCharacters_ReturnsCorrectOutputVariable()
        {
            //Arrange
            var inputValue = "/', '?', '!', '#', '@', '[', ']' ";

            // Act
            var result = MediumName.TryCreate(inputValue, out var name);
            // Assert
            result.Should().BeFalse(because: "MediumNames should not allow illegal characters", inputValue);
        }
        // TODO: add more tests
    }
}
