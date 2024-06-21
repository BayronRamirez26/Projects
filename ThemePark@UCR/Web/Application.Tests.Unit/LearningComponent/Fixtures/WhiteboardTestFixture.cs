using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Fixtures;

public class WhiteboardTestFixture
{
    public Mock<IWhiteboardRepository> MockWhiteboardRepository { get; }

    public IEnumerable<Whiteboard> whiteboards { get; set; }
    public Whiteboard validWhiteboard { get; set; }
    public Whiteboard invalidWhiteboard { get; set; }
    public WhiteboardService whiteboardService { get; set; }

    public WhiteboardTestFixture()
    {
        MockWhiteboardRepository = new Mock<IWhiteboardRepository>();


        invalidWhiteboard = null;

        validWhiteboard = new Whiteboard(
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

        whiteboardService = new WhiteboardService(MockWhiteboardRepository.Object);
    }

}
