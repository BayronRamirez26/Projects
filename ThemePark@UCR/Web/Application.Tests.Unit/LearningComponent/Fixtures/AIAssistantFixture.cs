using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Application.LearningComponents.Services;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningComponent.Fixtures;

public class AIAssistantTestFixture
{
    public Mock<IAIAssistantRepository> MockAIAssistantRepository { get; }

    public IEnumerable<AIAssistant> aIAssistants { get; set; }
    public AIAssistant validAIAssistant { get; set; }
    public AIAssistant invalidAIAssistant { get; set; }
    public AIAssistantService aIAssistantService { get; set; }

    public AIAssistantTestFixture()
    {
        MockAIAssistantRepository = new Mock<IAIAssistantRepository>();


        invalidAIAssistant = null;

        validAIAssistant = new AIAssistant(
            LComponentID.Create(1),
            MediumName.Create("AIAssistant test"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid()));

        aIAssistants = new List<AIAssistant> {
            new AIAssistant(
            LComponentID.Create(1),
            MediumName.Create("AIAssistant 1"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid())),

            new AIAssistant(
            LComponentID.Create(1),
            MediumName.Create("AIAssistant 2"),
            Size.Create(10),
            Size.Create(20),
            Coordinate.Create(10.0),
            Coordinate.Create(20.0),
            Coordinate.Create(10.0),
            Coordinate.Create(0.0),
            Coordinate.Create(0.0),
            GuidWrapper.Create(Guid.NewGuid()))
        };

        aIAssistantService = new AIAssistantService(MockAIAssistantRepository.Object);
    }

}
