using UnityEngine;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure
{

    [RequireComponent(typeof(CharacterController))]

    public class ApiClientPrototype : MonoBehaviour
    {
        [SerializeField]
        private UserSpawner _userSpawner;

        private ApiClientKiota _apiClient;

        private async Awaitable GetLearningSpacesAsync()
        {
            var response = await _apiClient.ListLearningspaces.GetAsync();

            // create the learning space with the first learning space of the response
            var index = 0;
            //var learningSpace = response[index];
            //while(learningSpace.LearningSpaceId != )


            // create the learning space with the first learning space of the response
            //CreateLearningSpace3D((float)learningSpace.SizeX.Value, (float)learningSpace.SizeY.Value, (float)learningSpace.SizeZ.Value, Color.blue, Color.red, Color.green);
            //Debug.Log(learningSpace.LearningSpaceName.Value);

            //CreateLearningSpace3D()

            //foreach (var learningSpace in response)
            //{
            //    Debug.Log(learningSpace.SizeX);
            //    Debug.Log(learningSpace.LearningSpaceName.Value);
            //}

            //_userSpawner.SpawnUsers(response);
        }


        // Start is called before the first frame update
        async void Start()
        {
            var requestAdapter = new HttpClientRequestAdapter(
                new AnonymousAuthenticationProvider());
            requestAdapter.BaseUrl = "https://localhost:7168/";
            _apiClient = new ApiClientKiota(requestAdapter);

            // _apiClient.ListLearningspaces.GetAsync();
            await GetLearningSpacesAsync();
        }

        // Update is called once per frame
         void Update()
        {
        
        }


        /// <summary>
        /// Create a 3D learning space with a roof, right wall, left wall, back wall and front wall
        /// The roof as a given color, same as the walls and the floor
        /// </summary>
        public void CreateLearningSpace3D(float sizeX, float sizeY, float sizeZ, Color roofColor, Color wallColor, Color floorColor)
        {
            Debug.Log("Creating learning space");
            Debug.Log(sizeX);
            Debug.Log(sizeY);
            Debug.Log(sizeZ);
            // create the roof
            GameObject roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
            roof.transform.localScale = new Vector3(sizeX, 0.1f, sizeZ);
            roof.transform.position = new Vector3(0, sizeY, 0);
            roof.GetComponent<Renderer>().material.color = roofColor;

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

    }
}
