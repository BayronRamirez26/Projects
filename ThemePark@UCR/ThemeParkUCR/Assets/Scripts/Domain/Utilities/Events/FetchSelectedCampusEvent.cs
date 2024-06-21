using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events
{
    public readonly struct FetchSelectedCampusEvent : IEvent
    {
        public string CampusName { get; }

        public FetchSelectedCampusEvent(string campusName)
        {
            CampusName = campusName;
        }
    }
}