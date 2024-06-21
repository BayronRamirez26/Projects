using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LevelById;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.Shared;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.LevelById.LevelByIdRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class AccessPointBehaviour : Interactable
    {
        private ApiClientKiota _apiClient;
        // Start is called before the first frame update

        public Guid levelGuid;

        void Start()
        {
            var requestAdapter = new HttpClientRequestAdapter(
                new AnonymousAuthenticationProvider());
            requestAdapter.BaseUrl = "https://localhost:7168/";
            _apiClient = new ApiClientKiota(requestAdapter);
        }

        public override async void Interact()
        {
            Debug.Log("Interacting with AccessPointBehaviour.");
            //base.Interact();
            //onInteraction.Invoke();
            SceneLevelTransferObject.Instance.LevelKey = levelGuid;

            // Prepare request configuration to make request to API
            var requestConfiguration = new Action<RequestConfiguration<LevelByIdRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new LevelByIdRequestBuilderGetQueryParameters
                {
                    LevelId = levelGuid
                };
            });

            // Don't reload the scene if is not null
            if (string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.UniversityName) &&
                string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.CampusName) &&
                string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.SiteName) &&
                string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.BuildingAcronym))
            {

                // Get level from the Id 
                var levelTarget = await _apiClient.LevelById.GetAsync(requestConfiguration);

                BuildingSceneDataTransfer.Instance.UniversityName = levelTarget.UniversityName.Value;
                BuildingSceneDataTransfer.Instance.CampusName = levelTarget.CampusName.Value;
                BuildingSceneDataTransfer.Instance.SiteName = levelTarget.SiteName.Value;
                BuildingSceneDataTransfer.Instance.BuildingAcronym = levelTarget.BuildingAcronym.Value;

            }

            SceneManager.LoadScene("LevelArea");

        }
    }
}
