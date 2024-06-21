using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Events
{
    public readonly struct FetchLevelsFromBuldingEvent : IEvent
    {
        public IEnumerable<Level> Levels { get; }

        public FetchLevelsFromBuldingEvent(IEnumerable<Level> levels)
        {
            Levels = levels;
        }
    }
}