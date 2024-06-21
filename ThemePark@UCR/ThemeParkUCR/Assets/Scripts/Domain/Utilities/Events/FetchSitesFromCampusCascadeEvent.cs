using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events
{
    public readonly struct FetchSitesFromCampusCascadeEvent : IEvent
    {
        public IEnumerable<string> SiteNames { get; }

        public FetchSitesFromCampusCascadeEvent(IEnumerable<string> siteNames)
        {
            SiteNames = siteNames;
        }
    }
}