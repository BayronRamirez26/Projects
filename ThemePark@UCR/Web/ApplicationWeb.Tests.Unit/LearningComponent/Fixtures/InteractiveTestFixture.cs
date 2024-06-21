using Moq;
using UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.ApplicationWeb.Tests.Unit.LearningComponent.Fixtures;

public class InteractiveScreenTestFixture
{
    public Mock<IInteractiveScreenRepository> MockInteractiveScreenRepository { get; }

    public IEnumerable<InteractiveScreen> interactiveScreens { get; set; }
    public InteractiveScreen validInteractiveScreen { get; set; }
    public InteractiveScreen invalidInteractiveScreen { get; set; }
    public InteractiveScreenService interactiveScreenService { get; set; }

    public InteractiveScreenTestFixture()
    {
        MockInteractiveScreenRepository = new Mock<IInteractiveScreenRepository>();


        invalidInteractiveScreen = null;

        validInteractiveScreen = new InteractiveScreen(
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

        interactiveScreenService = new InteractiveScreenService(MockInteractiveScreenRepository.Object);
    }

}
