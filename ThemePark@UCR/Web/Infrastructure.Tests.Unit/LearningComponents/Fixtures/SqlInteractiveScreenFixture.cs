using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningComponents.Fixtures;

public class SqlInteractiveScreenRepositoryFixture
{
    public IEnumerable<InteractiveScreen> interactiveScreens { get; private set; }
    public InteractiveScreen ValidInteractiveScreen { get; private set; }
    public InteractiveScreen? InvalidInteractiveScreen { get; private set; }

    public SqlInteractiveScreenRepositoryFixture()
    {
        InvalidInteractiveScreen = null;

        ValidInteractiveScreen = new InteractiveScreen(
            LComponentID.Create(1),
            MediumName.Create("InteractiveScreen test"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid()));

        interactiveScreens = new List<InteractiveScreen> {
            new InteractiveScreen(
            LComponentID.Create(1),
            MediumName.Create("InteractiveScreen 1"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid())),

            new InteractiveScreen(
            LComponentID.Create(1),
            MediumName.Create("InteractiveScreen 2"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid()))
        };
    }

}
