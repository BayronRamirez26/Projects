using JetBrains.Annotations;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Events;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.LevelBehaviour
{
    public class LevelManager : MonoBehaviour
    {

        [Inject]
        private ILevelService _levelService;

        [Inject]
        private IEventChannel _eventChannel;

        private async Awaitable GetLevelsFromBuildingAsync(string universityName, string campusName, string siteName, string buildingAcronym)
        {
            var levels = await _levelService.GetLevelsFromBuildingAsync(
                LongName.Create(universityName),
                LongName.Create(campusName),
                MediumName.Create(siteName),
                ShortName.Create(buildingAcronym)
            );
            _eventChannel.Fire(new FetchLevelsFromBuldingEvent(levels));
        }

        // Start is called before the first frame update
        async void Start()
        {
            if (!string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.UniversityName) &&
                !string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.CampusName) &&
                !string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.SiteName) &&
                !string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.BuildingAcronym))
            {
                await GetLevelsFromBuildingAsync(
                    BuildingSceneDataTransfer.Instance.UniversityName,
                    BuildingSceneDataTransfer.Instance.CampusName,
                    BuildingSceneDataTransfer.Instance.SiteName,
                    BuildingSceneDataTransfer.Instance.BuildingAcronym
                );
            }
        }
    }
}
 