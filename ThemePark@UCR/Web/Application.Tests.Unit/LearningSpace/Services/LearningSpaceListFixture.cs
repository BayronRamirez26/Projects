using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningSpace.Services.Classes;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningSpace.Services
{
    public class LearningSpaceListFixture
    {
        public LearningSpaces LearningSpacesValid { get; set; }
        public LearningSpaces LearningSpacesInvalid { get; set; }
        public IEnumerable<LearningSpaces> LearningSpacesList { get; set; }
        public IEnumerable<Projector> ProjectorsList { get; set; }
        public IEnumerable<Whiteboard> WhiteboardsList { get; set; }
        public IEnumerable<InteractiveScreen> InteractiveScreensList { get; set; }
        public IEnumerable<AccessPoint> AccessPointsList { get; set; }
        public Mock<ILearningSpaceRepository> MockLearningSpaceRepository { get; }
        public LearningSpaceService LearningSpaceService { get; }

        public LSType LSType { get; set; }

        public GuidWrapper LSTypeguid { get; set; }

        public LearningSpaceListFixture()
        {
            MockLearningSpaceRepository = new Mock<ILearningSpaceRepository>();

            LSType = new LSType(
                Guid.NewGuid(),
                MediumName.Create("Type 1")
           );

            LSTypeguid = GuidWrapper.Create(LSType.Id);

            LearningSpacesValid = new LearningSpaces(
                GuidWrapper.Create(Guid.NewGuid()),
                ShortName.Create("Space 1"),
                DoubleWrapper.Create(10.0), // sizeX
                DoubleWrapper.Create(10.0), // sizeY
                DoubleWrapper.Create(10.0), // sizeZ
                MediumName.Create("Floor Color 1"), // floor color
                MediumName.Create("Ceiling Color 1"), // ceiling color
                MediumName.Create("Walls Color 1"), // wall color
                GuidWrapper.Create(Guid.NewGuid()),
                GuidWrapper.Create(Guid.NewGuid())
            );

            LearningSpacesInvalid = null;

            LearningSpacesList = new List<LearningSpaces>
        {
            new LearningSpaces(
                GuidWrapper.Create(Guid.NewGuid()),
                ShortName.Create("Space 1"),
                DoubleWrapper.Create(10.0), // sizeX
                DoubleWrapper.Create(10.0), // sizeY
                DoubleWrapper.Create(10.0), // sizeZ
                MediumName.Create("Floor Color 1"), // floor color
                MediumName.Create("Ceiling Color 1"), // ceiling color
                MediumName.Create("Walls Color 1"), // wall color
                GuidWrapper.Create(Guid.NewGuid()),
                GuidWrapper.Create(Guid.NewGuid())
            ),
            new LearningSpaces(
                GuidWrapper.Create(Guid.NewGuid()),
                ShortName.Create("Space 2"),
                DoubleWrapper.Create(10.0), // sizeX
                DoubleWrapper.Create(10.0), // sizeY
                DoubleWrapper.Create(10.0), // sizeZ
                MediumName.Create("Floor Color 1"), // floor color
                MediumName.Create("Ceiling Color 1"), // ceiling color
                MediumName.Create("Walls Color 1"), // wall color
                GuidWrapper.Create(Guid.NewGuid()),
                GuidWrapper.Create(Guid.NewGuid())
            )
        };

            ProjectorsList = new List<Projector>
        {
            new Projector(
                 MediumName.Create("Proyector 1"),
                 Size.Create(10.0),
                 Size.Create(10.0),
                 Coordinate.Create(10.0),
                 Coordinate.Create(10.0),
                 Coordinate.Create(10.0),
                 Coordinate.Create(10.0),
                 Coordinate.Create(10.0),
                 GuidWrapper.Create(Guid.NewGuid())
            ),
            new Projector(
                MediumName.Create("Proyector 2"),
                Size.Create(20.0),
                Size.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                GuidWrapper.Create(Guid.NewGuid())
            )
        };

            WhiteboardsList = new List<Whiteboard>
        {
            new Whiteboard(
                MediumName.Create("Whiteboard 1"),
                Size.Create(10.0),
                Size.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                GuidWrapper.Create(Guid.NewGuid())
            ),
            new Whiteboard(
                MediumName.Create("Whiteboard 2"),
                Size.Create(20.0),
                Size.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                Coordinate.Create(20.0),
                GuidWrapper.Create(Guid.NewGuid())
            )
        };

            InteractiveScreensList = new List<InteractiveScreen>
        {
            new InteractiveScreen(
                MediumName.Create("InteractiveScreen 1"),
                Size.Create(10.0),
                Size.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                GuidWrapper.Create(Guid.NewGuid())
            ),
            new InteractiveScreen(
                MediumName.Create("InteractiveScreen 2"),
                Size.Create(10.0),
                Size.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                Coordinate.Create(10.0),
                GuidWrapper.Create(Guid.NewGuid())
            )
        };

            AccessPointsList = new List<AccessPoint>
        {
            new AccessPoint(
                GuidWrapper.Create(Guid.NewGuid()), // access point id
                GuidWrapper.Create(Guid.NewGuid()), // LS id
                GuidWrapper.Create(Guid.NewGuid()), // Level id
                1.0,
                1.0,
                1.0,
                0.0,
                0.0
            ),
            new AccessPoint(
                GuidWrapper.Create(Guid.NewGuid()), // access point id
                GuidWrapper.Create(Guid.NewGuid()), // LS id
                GuidWrapper.Create(Guid.NewGuid()), // Level id
                10.0,
                10.0,
                10.0,
                90.0,
                90.0
            )
        };

            LearningSpaceService = new LearningSpaceService(MockLearningSpaceRepository.Object);
        }
    }
}
