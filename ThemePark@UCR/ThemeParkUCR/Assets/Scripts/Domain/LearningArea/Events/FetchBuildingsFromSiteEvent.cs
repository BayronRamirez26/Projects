using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Events
{
    public readonly struct FetchBuildingsFromSiteEvent : IEvent
    {
        public IEnumerable<Building> Buildings { get; }

        public FetchBuildingsFromSiteEvent(IEnumerable<Building> buildings)
        {
            Buildings = buildings;
        }
    }
}