using Castle.Core.Smtp;
using Moq;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.Domain.LearningSpace.Repositories;

namespace UCR.ECCI.PI.ThemePark_UCR.Application.Tests.Unit.LearningSpace.Services;

public class AccessPointFixture
{
    // Default returnAccessPoint is a VALID INPUT
    public AccessPoint returnAccessPoint { get; private set; }

    public IEnumerable<AccessPoint> listAccessPoint { get; private set; }

    public GuidWrapper AccessPointId { get; private set; }
    public enum actualContext
    {
        ValidInput,
        NullInput,
        WhenGivenNoEmptyList
    };

    public void ChangeContext(actualContext inputContext)
    {
        switch (inputContext)
        {
            case actualContext.ValidInput:
                returnAccessPoint = new AccessPoint(
                GuidWrapper.Create(new Guid()),
                GuidWrapper.Create(new Guid()),
                GuidWrapper.Create(new Guid()),
                0.0, 0.0, 0.0, 0.0, 0.0);
                break;
            case actualContext.NullInput:
                returnAccessPoint = null;
                break;
            case actualContext.WhenGivenNoEmptyList:
                listAccessPoint = new List<AccessPoint>
                {
                    new AccessPoint(
                        GuidWrapper.Create(Guid.NewGuid()),
                        GuidWrapper.Create(Guid.NewGuid()),
                        GuidWrapper.Create(Guid.NewGuid()),
                        0.0, 0.0, 0.0, 0.0, 0.0),
                    new AccessPoint(
                        GuidWrapper.Create(Guid.NewGuid()),
                        GuidWrapper.Create(Guid.NewGuid()),
                        GuidWrapper.Create(Guid.NewGuid()),
                        0.0, 0.0, 0.0, 0.0, 0.0)
                };
                break;
        }
    }

}
