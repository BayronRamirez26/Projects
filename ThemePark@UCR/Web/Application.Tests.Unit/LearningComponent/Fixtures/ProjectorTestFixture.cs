using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Fixtures;

public class ProjectorTestFixture
{
    public Mock<IProjectorRepository> MockProjectorRepository { get; }

    public IEnumerable<Projector> projectors { get; set; }
    public Projector validProjector { get; set; }
    public Projector invalidProjector { get; set; }
    public ProjectorService projectorService { get; set; }

    public ProjectorTestFixture()
    {
        MockProjectorRepository = new Mock<IProjectorRepository>();


        invalidProjector = null;

        validProjector = new Projector(
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

        projectorService = new ProjectorService(MockProjectorRepository.Object);
    }

}
