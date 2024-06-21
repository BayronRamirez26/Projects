using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Events;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteBehaviour;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour
{
    public class BuildingManager : MonoBehaviour
    {
        
        [Inject]
        private IBuildingService _buildingService;

        [Inject]
        private IEventChannel _eventChannel;

        private readonly string UniversityName = "Universidad de Costa Rica";

        // Start is called before the first frame update
        async void Start()
        {
            try
            {
                if (!string.IsNullOrEmpty(SiteDataStore.Instance.CampusName) &&
                    !string.IsNullOrEmpty(SiteDataStore.Instance.SiteName))
                {
                    await GetBuildingsFromSiteAsync(SiteDataStore.Instance.CampusName,
                                                    SiteDataStore.Instance.SiteName);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        private async Awaitable GetBuildingsFromSiteAsync(string campusName, string siteName)
        {
            var buildings = await _buildingService.GetBuildingsFromSiteAsync(
                LongName.Create(UniversityName),
                LongName.Create(campusName),
                MediumName.Create(siteName)
            );
            _eventChannel.Fire(new FetchBuildingsFromSiteEvent(buildings));
        }

    }
}
