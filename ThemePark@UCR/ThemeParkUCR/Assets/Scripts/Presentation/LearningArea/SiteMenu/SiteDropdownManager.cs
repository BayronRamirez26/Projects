using TMPro;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.Utilities.Services;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteMenu
{
    public class SiteDropdownManager : MonoBehaviour
    {

        [Inject]
        private IDropdownCascadeService _cascadeService;

        [Inject]
        private IEventChannel _eventChannel;

        // Start is called before the first frame update
        void Start()
        {
            // listen for the FetchSelectedCampusEvent, this event is fired when a campus is selected
            // in the campus dropdown in the loader
            _eventChannel.Subscribe<FetchSelectedCampusEvent>(OnFetchSelectedCampusEvent);
        }

        void OnDestroy()
        {
            _eventChannel.Unsubscribe<FetchSelectedCampusEvent>(OnFetchSelectedCampusEvent);
        }

        private async void OnFetchSelectedCampusEvent(FetchSelectedCampusEvent @event)
        {
            // Call GetSiteFromCampus with the selected campus name
            await GetSiteFromCampus(@event.CampusName);
        }

        private async Awaitable GetSiteFromCampus(string campusName)
        {
            var campusNames = await _cascadeService.GetSitesFromCampus(campusName);
            _eventChannel.Fire(new FetchSitesFromCampusCascadeEvent(campusNames));
        }
    }
}
