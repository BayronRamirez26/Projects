using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events
{
    public readonly struct FetchCampusesFromUniversityCascadeEvent : IEvent
    {
        public IEnumerable<string> CampusNames { get; }

        public FetchCampusesFromUniversityCascadeEvent(IEnumerable<string> campusNames)
        {
            CampusNames = campusNames;
        }
    }
}