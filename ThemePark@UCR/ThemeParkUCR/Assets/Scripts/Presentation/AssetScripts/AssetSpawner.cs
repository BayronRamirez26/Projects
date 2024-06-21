using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using Microsoft.Kiota.Abstractions;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetSiteofcampus.GetSiteofcampusRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetProjectorsOfLearningSpace.GetProjectorsOfLearningSpaceRequestBuilder;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class AssetSpawner : MonoBehaviour
    {
        // Reference to the AccessPoint prefab
        public GameObject accessPointPrefab;

        public GameObject projectorPrefab;


        // Boolean value to check if this is a spawner
        public bool isSpawner = true;

        // Parameters for position, rotation, and size
        public Vector3 position = Vector3.zero;
        public Vector3 rotation = Vector3.zero;
        public Vector3 size = new Vector3(2, 2, 2);
        private ApiClientKiota _apiClient;
        
        private async Awaitable GetProjectorsOfLearningSpaceAsync()
        {
            Guid input = new Guid("d406ab33-140e-4b23-899d-c29acbbb2bc2");
            var requestConfiguration = new Action<RequestConfiguration<GetProjectorsOfLearningSpaceRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new GetProjectorsOfLearningSpaceRequestBuilderPostQueryParameters
                {
                    InputId = input
                };
            });
            var response = await _apiClient.GetProjectorsOfLearningSpace.PostAsync(requestConfiguration);

            foreach (var projector in response)
            {

                 GameObject projectorInstance = Instantiate(projectorPrefab);

                // Set the position and size based on the database values
                projectorInstance.transform.position = new Vector3((float)projector.PositionX.Value, (float)projector.PositionY.Value, (float)projector.PositionZ.Value);
                projectorInstance.transform.localScale = new Vector3((float)projector.SizeX.Value, (float)projector.SizeY.Value, 1);

                // Optionally, you can set the name or other properties
                projectorInstance.name = projector.LearningComponentName.Value;
                Console.WriteLine(projector.LearningComponentName.ToString() , projector.PositionX);
            }
        }

        async void Start()
        {
            // Create a transparent cube
            GameObject spawner = GameObject.CreatePrimitive(PrimitiveType.Plane);
            spawner.transform.localScale = size;
            spawner.transform.position = position;
            spawner.transform.rotation = Quaternion.Euler(rotation);

            // Make the cube transparent
            Renderer renderer = spawner.GetComponent<Renderer>();
            Color transparentColor = new Color(1, 1, 1, 0.3f);
            Material transparentMaterial = new Material(Shader.Find("Standard"));
            transparentMaterial.color = transparentColor;
            renderer.material = transparentMaterial;



            var requestAdapter = new HttpClientRequestAdapter(
                new AnonymousAuthenticationProvider());
            requestAdapter.BaseUrl = "https://localhost:7168/";
            _apiClient = new ApiClientKiota(requestAdapter);

            await GetProjectorsOfLearningSpaceAsync();




            // Disable the collider to make it non-colliding
            Collider collider = spawner.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            // Check if this is a spawner and instantiate the AccessPoint prefab
            if (isSpawner && accessPointPrefab != null)
            {
                Instantiate(accessPointPrefab, position, Quaternion.Euler(rotation));
            }
        }

        void Update()
        {
            // Optional: Add any update logic here
        }
    }
}
