using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Events
{
    public readonly struct FetchAccessPointsFromLevelEvent : IEvent
    {
        public IEnumerable<AccessPoint> AccessPoints { get; }

        public FetchAccessPointsFromLevelEvent(IEnumerable<AccessPoint> accessPoints)
        {
            AccessPoints = accessPoints;
        }
    }
}