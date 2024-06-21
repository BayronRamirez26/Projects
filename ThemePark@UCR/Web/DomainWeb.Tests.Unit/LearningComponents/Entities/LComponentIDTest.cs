using FluentAssertions;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningComponents.Fixtures;


namespace UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Tests.Unit.LearningComponents.Entities;
public class LComponentIDTests : IClassFixture<LComponentIDFixture>
{
    private readonly LComponentIDFixture _fixture;

public LComponentIDTests(LComponentIDFixture fixture)
{
    _fixture = fixture;
}

[Fact]
public void Create_ValidValue_ReturnsLComponentID()
{
    _fixture.ChangeContext(LComponentIDFixture.Context.ValidValue);
    var componentID = _fixture.ComponentID;
    componentID.Should().NotBeNull();
    componentID.Value.Should().Be(5);
}

[Fact]
public void Create_NullValue_ThrowsArgumentException()
{
    Action act = () => _fixture.ChangeContext(LComponentIDFixture.Context.NullValue);
    act.Should().Throw<ArgumentException>()
       .WithMessage("Invalid integer Value.*");
}

[Fact]
public void Create_ValueBelowMinValue_ThrowsArgumentException()
{
    Action act = () => _fixture.ChangeContext(LComponentIDFixture.Context.ValueBelowMin);
    act.Should().Throw<ArgumentException>()
       .WithMessage("Invalid integer Value.*");
}
/*
[Fact]
public void Create_ValueAboveMaxValue_ThrowsArgumentException()
{
    Action act = () => _fixture.ChangeContext(LComponentIDFixture.Context.ValueAboveMax);
    act.Should().Throw<ArgumentException>()
       .WithMessage("Invalid integer Value.*");
}*/

[Fact]
public void TryCreate_ValidValue_ReturnsTrueAndLComponentID()
{
    var value = 5;
    var result = LComponentID.TryCreate(value, out var componentID);
    result.Should().BeTrue();
    componentID.Value.Should().Be(value);
}

[Fact]
public void TryCreate_NullValue_ReturnsFalseAndInvalidID()
{
    var result = LComponentID.TryCreate(null, out var componentID);
    result.Should().BeFalse();
    componentID.Value.Should().Be(-1); // Invalid ID has value -1
}

[Fact]
public void TryCreate_ValueBelowMinValue_ReturnsFalseAndInvalidID()
{
    var value = -1;
    var result = LComponentID.TryCreate(value, out var componentID);
    result.Should().BeFalse();
    componentID.Value.Should().Be(-1); // Invalid ID has value -1
}

[Fact]
public void TryCreate_ValueAboveMaxValue_ReturnsFalseAndInvalidID()
{
    var value = int.MaxValue + 1L; // Since int.MaxValue is max for int, using long to test above int range.
    var result = LComponentID.TryCreate((int?)value, out var componentID);
    result.Should().BeFalse();
    componentID.Value.Should().Be(-1); // Invalid ID has value -1
}
}