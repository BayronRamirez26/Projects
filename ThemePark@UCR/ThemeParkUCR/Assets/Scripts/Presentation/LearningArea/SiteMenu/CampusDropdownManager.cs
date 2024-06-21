using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.Utilities.Services;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteMenu
{
    public class CampusDropdownManager : MonoBehaviour
    {

        [Inject]
        private IDropdownCascadeService _cascadeService;

        [Inject]
        private IEventChannel _eventChannel;

        private readonly static string UniversityName = "Universidad de Costa Rica";

        private async Awaitable GetCampusFromUniversity()
        {
            var campusNames = await _cascadeService.GetCampusFromUniversity(UniversityName);
            _eventChannel.Fire(new FetchCampusesFromUniversityCascadeEvent(campusNames));
        }

        // Start is called before the first frame update
        async void Start()
        {
            await GetCampusFromUniversity();
        }

    }
}
