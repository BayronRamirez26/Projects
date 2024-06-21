using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events
{
    public readonly struct FetchSelectedSiteEvent : IEvent
    {
        public string SiteName { get; }

        public FetchSelectedSiteEvent(string siteName)
        {
            SiteName = siteName;
        }
    }
}