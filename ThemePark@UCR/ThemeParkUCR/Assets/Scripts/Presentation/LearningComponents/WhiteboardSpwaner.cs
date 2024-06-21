using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System.Collections.Generic;
using TMPro;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;
using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure
{
    public class WhiteboardSpawner : MonoBehaviour
    {

        // The following fields will be editable from the Unity Editor
        [SerializeField]
        // Template used for the user prefab
        private GameObject _whiteboardPrefab;

        // Building label prefab
        [SerializeField]
        private GameObject _whiteboardLabel;

        private ApiClientKiota _apiClient;

        //private List<Whiteboard> _whiteboards;

        private const float DEFAULTHEIGTH = 2f; // height with one level
        private const float DEFAULTLENGTH = 2f;
        private const float DEFAULTWIDTH = 4f;
        // Start is called before the first frame update
        async void Start()
        {
            var requestAdapter = new HttpClientRequestAdapter(
                new AnonymousAuthenticationProvider());
            requestAdapter.BaseUrl = "https://localhost:7168/";
            _apiClient = new ApiClientKiota(requestAdapter);

            await GetWhiteboardsAsync();
            SpawnWhiteboards();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private async Awaitable GetWhiteboardsAsync()
        {
            //_whiteboards = await _apiClient.ListWhiteboard.GetAsync();
        }

        private void SpawnWhiteboards()
        {
            //foreach (var whiteboard in _whiteboards)
            //{
                
            //    // Building game object
            //    var whiteboardGameObject = Instantiate(
            //        _whiteboardPrefab,
            //        new Vector3(
            //            (float)whiteboard.PositionX.Value,
            //            (float)DEFAULTHEIGTH,
            //            (float)whiteboard.PositionY.Value
            //            ),
            //        Quaternion.Euler(0, 0, 0)
            //    );
            //    whiteboardGameObject.transform.localScale = new Vector3(
            //        (float)DEFAULTLENGTH,
            //        (float)DEFAULTHEIGTH,
            //        (float)DEFAULTWIDTH
            //    );
                
            //    // Building label game object
            //    var whiteboardLabelGameObject = Instantiate(
            //        _whiteboardLabel,
            //        new Vector3(
            //            (float)whiteboard.PositionX.Value,
            //            (float)DEFAULTHEIGTH + 10,
            //            (float)whiteboard.PositionY.Value
            //        ),
            //        Quaternion.Euler(180, 0, 180)
            //    );
            //    var whiteboardName = whiteboardLabelGameObject.GetComponentInChildren<TextMeshProUGUI>();
            //    whiteboardName.text = $"{whiteboard.LearningComponentName.Value}";
            //}
        }

    }
}