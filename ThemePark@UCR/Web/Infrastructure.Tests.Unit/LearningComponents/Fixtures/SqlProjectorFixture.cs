using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningComponents.Fixtures;

public class SqlProjectorRepositoryFixture
{
    public IEnumerable<Projector> projectors { get; private set; }
    public Projector ValidProjector { get; private set; }
    public Projector? InvalidProjector { get; private set; }

    public SqlProjectorRepositoryFixture()
    {
        InvalidProjector = null;

        ValidProjector = new Projector(
            LComponentID.Create(1),
            MediumName.Create("Projector test"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid()));

        projectors = new List<Projector> {
            new Projector(
            LComponentID.Create(1),
            MediumName.Create("Projector 1"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid())),

            new Projector(
            LComponentID.Create(1),
            MediumName.Create("Projector 2"),
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
