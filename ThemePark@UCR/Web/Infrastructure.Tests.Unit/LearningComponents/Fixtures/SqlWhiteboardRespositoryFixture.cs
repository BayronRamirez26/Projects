using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningComponents.Fixtures;

public class SqlWhiteboardRepositoryFixture
{
    public IEnumerable<Whiteboard> whiteboards { get; private set; }
    public Whiteboard ValidWhiteboard { get; private set; }
    public Whiteboard? InvalidWhiteboard { get; private set; }

    public SqlWhiteboardRepositoryFixture()
    {
        InvalidWhiteboard = null;

        ValidWhiteboard = new Whiteboard(
            LComponentID.Create(1),
            MediumName.Create("Whiteboard test"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid()));

        whiteboards = new List<Whiteboard> {
            new Whiteboard(
            LComponentID.Create(1),
            MediumName.Create("Whiteboard 1"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid())),

            new Whiteboard(
            LComponentID.Create(1),
            MediumName.Create("Whiteboard 2"),
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
