using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.Tests.Unit.LearningComponents.Fixtures;

public class SqlAIAssistantRespositoryFixture
{
    public IEnumerable<AIAssistant> aIAssistants { get; private set; }
    public AIAssistant ValidAIAssistant { get; private set; }
    public AIAssistant? InvalidAIAssistant { get; private set; }

    public SqlAIAssistantRespositoryFixture()
    {
        InvalidAIAssistant = null;

        ValidAIAssistant = new AIAssistant(
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
    }

}
