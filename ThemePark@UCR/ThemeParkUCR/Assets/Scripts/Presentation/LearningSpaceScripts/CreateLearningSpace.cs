using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using UnityEngine;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure;
using UnityEngine.SceneManagement;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using Microsoft.Kiota.Abstractions;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetProjectorsOfLearningSpace.GetProjectorsOfLearningSpaceRequestBuilder;
using System;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetWhiteboardOfLearningSpace.GetWhiteboardOfLearningSpaceRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetInteractiveScreenOfLearningSpace.GetInteractiveScreenOfLearningSpaceRequestBuilder;
using static UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.GetAccessPointsOfLearningSpace.GetAccessPointsOfLearningSpaceRequestBuilder;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;
using Color = UnityEngine.Color;
using UnityEditor.SearchService;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class CreateLearningSpace : MonoBehaviour
    {
        [SerializeField]
        private UserSpawner _userSpawner;
        public GameObject projectorPrefab;
        public GameObject whiteboardPrefab;
        //public GameObject WhiteboardCENTERED;
        public GameObject interactiveScreenPrefab;
        public GameObject accessPointPrefab;
        private ApiClientKiota _apiClient;

        private async Awaitable GetLearningSpacesAsync()
        {
            var response = await _apiClient.ListLearningspaces.GetAsync();

            // create the learning space with the first learning space of the response
            var index = 0;
            var learningSpace = response[index];
            while (learningSpace.LearningSpaceId.Value.Value != ViewLearningSpaceButton.learningSpaceGuid && index < response.Count)
            {
                Debug.Log(learningSpace.LearningSpaceId.Value.Value);
                index += 1;
                learningSpace = response[index];
            }
            Debug.Log(learningSpace.LearningSpaceId.Value.Value);

            // cast the colors from hex to Color
            Color roofColor = new Color();
            ColorUtility.TryParseHtmlString(learningSpace.CeilingColor.Value, out roofColor);
            Color wallColor = new Color();
            ColorUtility.TryParseHtmlString(learningSpace.WallsColor.Value, out wallColor);
            Color floorColor = new Color();
            ColorUtility.TryParseHtmlString(learningSpace.FloorColor.Value, out floorColor);


            // create the learning space with the first learning space of the response
            CreateLearningSpace3D((float)learningSpace.SizeX.Value, (float)learningSpace.SizeY.Value, (float)learningSpace.SizeZ.Value, roofColor, wallColor, floorColor);

            await GetProjectorsOfLearningSpaceAsync();

            await GetWhiteboardOfALearningSpacesAsync();

            await GetInteractiveScreenOfALearningSpacesAsync();

            await GetAccessPointOfALearningSpaceAsync();
        }


        // Start is called before the first frame update
        async void Start()
        {
            var requestAdapter = new HttpClientRequestAdapter(
                new AnonymousAuthenticationProvider());
            requestAdapter.BaseUrl = "https://localhost:7168/";
            _apiClient = new ApiClientKiota(requestAdapter);

            await GetLearningSpacesAsync();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                SceneManager.LoadScene("ChooseLearningSpace");

            }

        }


        /// <summary>
        /// Create a 3D learning space with a roof, right wall, left wall, back wall and front wall
        /// The roof as a given color, same as the walls and the floor
        /// </summary>
        public void CreateLearningSpace3D(float sizeX, float sizeY, float sizeZ, Color roofColor, Color wallColor, Color floorColor)
        {
            // create the roof
            GameObject roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
            roof.transform.localScale = new Vector3(sizeX, 0.1f, sizeZ);
            roof.transform.position = new Vector3(0, sizeY, 0);
            roof.GetComponent<Renderer>().material.color = roofColor;

            // change the size of the floor
            transform.localScale = new Vector3(sizeX + 1.0f, 1.0f, sizeZ + 1.0f);

            // create right wall
            GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rightWall.transform.localScale = new Vector3(0.1f, sizeY, sizeZ);
            rightWall.transform.position = new Vector3(sizeX / 2, sizeY / 2, 0);
            rightWall.GetComponent<Renderer>().material.color = wallColor;

            // create left wall
            GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leftWall.transform.localScale = new Vector3(0.1f, sizeY, sizeZ);
            leftWall.transform.position = new Vector3(-sizeX / 2, sizeY / 2, 0);
            leftWall.GetComponent<Renderer>().material.color = wallColor;

            // create back wall
            GameObject backWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            backWall.transform.localScale = new Vector3(sizeX, sizeY, 0.1f);
            backWall.transform.position = new Vector3(0, sizeY / 2, sizeZ / 2);
            backWall.GetComponent<Renderer>().material.color = wallColor;

            // create front wall
            GameObject frontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            frontWall.transform.localScale = new Vector3(sizeX, sizeY, 0.1f);
            frontWall.transform.position = new Vector3(0, sizeY / 2, -sizeZ / 2);
            frontWall.GetComponent<Renderer>().material.color = wallColor;

            // change the floor color
            GetComponent<Renderer>().material.color = floorColor;
        }

        private async Awaitable GetProjectorsOfLearningSpaceAsync()
        {

            Guid input = ViewLearningSpaceButton.learningSpaceGuid;
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
                projectorInstance.transform.rotation = Quaternion.Euler(0, (float)projector.RotationX.Value, 0);


                // Optionally, you can set the name or other properties
                projectorInstance.name = projector.LearningComponentName.Value;
                Console.WriteLine(projector.LearningComponentName.ToString(), projector.PositionX);
            }
        }


        private async Awaitable GetWhiteboardOfALearningSpacesAsync()
        {
            // Get ID of the learning space
            Guid input = ViewLearningSpaceButton.learningSpaceGuid;

            var requestConfiguration = new Action<RequestConfiguration<
                GetWhiteboardOfLearningSpaceRequestBuilderPostQueryParameters>>(config =>
                {
                    config.QueryParameters = new GetWhiteboardOfLearningSpaceRequestBuilderPostQueryParameters
                    {
                        InputId = input
                    };
                });
            // Ask to API Client the learning space
            var response = await _apiClient.GetWhiteboardOfLearningSpace.PostAsync(requestConfiguration);

            foreach (var whiteboard in response)
            {
                // Create a whiteboard object
                GameObject whiteboardInstance = Instantiate(whiteboardPrefab);
                whiteboardInstance.name = whiteboard.LearningComponentName.Value;

                // Set the position and size based on the database values
                whiteboardInstance.transform.position = new Vector3((float)whiteboard.PositionX.Value, (float)whiteboard.PositionY.Value, (float)whiteboard.PositionZ.Value);
                whiteboardInstance.transform.localScale = new Vector3((float)whiteboard.SizeX.Value, (float)0.5, -1 * (float)whiteboard.SizeY.Value);
                whiteboardInstance.transform.rotation = Quaternion.Euler(-90, (float)whiteboard.RotationX.Value, 0);
            }
        }

        private async Awaitable GetInteractiveScreenOfALearningSpacesAsync()
        {
            // Get ID of the learning space
            Guid input = ViewLearningSpaceButton.learningSpaceGuid;

            var requestConfiguration = new Action<RequestConfiguration<
                               GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters>>(config =>
                               {
                                   config.QueryParameters = new GetInteractiveScreenOfLearningSpaceRequestBuilderPostQueryParameters
                                   {
                                       InputId = input
                                   };
                               });
            // Ask to API Client the learning space
            var response = await _apiClient.GetInteractiveScreenOfLearningSpace.PostAsync(requestConfiguration);

            foreach (var interactiveScreen in response)
            {
                // Create a whiteboard object
                GameObject interactiveScreenInstance = Instantiate(interactiveScreenPrefab);
                interactiveScreenInstance.name = interactiveScreen.LearningComponentName.Value;

                // Set the position and size based on the database values
                interactiveScreenInstance.transform.position = new Vector3((float)interactiveScreen.PositionX.Value, (float)interactiveScreen.PositionY.Value, (float)interactiveScreen.PositionZ.Value);
                interactiveScreenInstance.transform.localScale = new Vector3((float)interactiveScreen.SizeX.Value, (float)interactiveScreen.SizeY.Value, 1);
                interactiveScreenInstance.transform.rotation = Quaternion.Euler(0, (float)interactiveScreen.RotationX.Value, 0);
            }
        }

        private async Awaitable GetAccessPointOfALearningSpaceAsync()
        {
            // Get ID of a Learning Space
            Guid input = ViewLearningSpaceButton.learningSpaceGuid;

            var requestConfiguration = new Action<RequestConfiguration
                <GetAccessPointsOfLearningSpaceRequestBuilderPostQueryParameters>>(config =>
                {
                    config.QueryParameters = new GetAccessPointsOfLearningSpaceRequestBuilderPostQueryParameters
                    {
                        InputId = input
                    };
                });

            var response = await _apiClient.GetAccessPointsOfLearningSpace.PostAsync(requestConfiguration);
            foreach(var accessPoint in response)
            {
                GameObject interacticeAccessPointInstance = Instantiate(accessPointPrefab);
                interacticeAccessPointInstance.name = accessPoint.AccessPointId.Value.ToString();
                interacticeAccessPointInstance.transform.position = new Vector3((float)accessPoint.CoordX.Value, (float)accessPoint.CoordY.Value, (float)accessPoint.CoordZ.Value);
                interacticeAccessPointInstance.transform.rotation = Quaternion.Euler((float)accessPoint.RotationX.Value, (float)accessPoint.RotationY.Value, 0);

                var accessPointBehaviour = interacticeAccessPointInstance.GetComponent<AccessPointBehaviour>();
                if (accessPointBehaviour != null)
                {
                    accessPointBehaviour.levelGuid = (Guid)accessPoint.LevelId.Value;
                }
            }

        }



    }
}