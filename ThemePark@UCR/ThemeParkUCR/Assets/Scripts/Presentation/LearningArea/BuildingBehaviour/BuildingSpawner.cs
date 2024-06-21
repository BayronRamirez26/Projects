using TMPro;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Events;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour
{
    public class BuildingSpawner : MonoBehaviour
    {

        // The following fields will be editable from the Unity Editor
        [SerializeField]
        // Template used for the user prefab
        private GameObject _buildingPrefab;

        // Building label prefab
        [SerializeField]
        private GameObject _buildingLabel;

        // Building access point prefab
        [SerializeField]
        private GameObject _buildingAccessPoint;

        // Building access point prefab
        [SerializeField]
        private GameObject _playerInstance;


        [Inject]
        private IEventChannel _eventChannel;

        private const float DEFAULTHEIGTH = 8f; // height with one level

     

        // Start is called before the first frame update
        void Start()
        {
            _eventChannel.Subscribe<FetchBuildingsFromSiteEvent>(OnFetchBuildingsFromSiteEvent);
        }

        void OnDestroy()
        {
            _eventChannel.Unsubscribe<FetchBuildingsFromSiteEvent>(OnFetchBuildingsFromSiteEvent);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnFetchBuildingsFromSiteEvent(FetchBuildingsFromSiteEvent @event)
        {
            foreach (var building in @event.Buildings)
            {
                float? heigth = DEFAULTHEIGTH * building.LevelCount.Value;
                if (heigth == null || heigth == 0)
                {
                    heigth = DEFAULTHEIGTH;
                }

                // Building game object
                var buildingPosition = new Vector3(
                    (float)building.CenterX.Value,
                    (float)heigth / 2,
                    (float)building.CenterY.Value
                );
                var buldingRotation = Quaternion.Euler(0, (float)building.Rotation.Value, 0);

                // Create building as game object
                var buildingGameObject = Instantiate(
                    _buildingPrefab,
                    buildingPosition,
                    buldingRotation
                );

                // Set building size
                buildingGameObject.transform.localScale = new Vector3(
                    (float)building.Length.Value,
                    (float)heigth,
                    (float)building.Width.Value
                );
                // Set color of the building
                ColorUtility.TryParseHtmlString(building.WallsColor.Value, out var WallsColor);
                buildingGameObject.GetComponent<Renderer>().material.color = WallsColor;

                // Door properties
                // Calculate door position in local space (front of the building)
                Vector3 doorWorldPosition = DoorPositionCalculator(building);

                // Access Point (Door) game object
                var doorGameObject = Instantiate(
                    _buildingAccessPoint,
                    doorWorldPosition,
                    buldingRotation
                );

                // Adjust the door's rotation
                doorGameObject.transform.rotation = buildingGameObject.transform.rotation;

                // Set building data to the door, to be used in the next scene
                var buildingDataStore = doorGameObject.transform.Find("BuildingData").GetComponent<BuildingDataStore>();

                //var buildingDataStore = buildingDataStore
                if (buildingDataStore != null)
                {
                    buildingDataStore.UniversityName = building.UniversityName.Value;
                    buildingDataStore.CampusName = building.CampusName.Value;
                    buildingDataStore.SiteName = building.SiteName.Value;
                    buildingDataStore.BuildingAcronym = building.BuildingAcronym.Value;
                }

                // Building label game object
                var buildingLabelGameObject = Instantiate(
                    _buildingLabel,
                    new Vector3(
                        (float)building.CenterX.Value,
                        (float)heigth + 5,
                        (float)building.CenterY.Value
                    ),
                    Quaternion.Euler(0, (float)building.Rotation.Value, 0)
                );
                var buildingName = buildingLabelGameObject.GetComponentInChildren<TextMeshProUGUI>();
                buildingName.text = $"{building.BuildingName.Value}";
            }

            // if the building access point position is 0,0,0, the player will spawn in the center of the scene
            if (BuildingSceneDataTransfer.Instance.BuildingAccessPointPosition != Vector3.zero)
            {
                PlayerSpawn();
            }

        }

        // TODO FIX and test this method and put it in a helper class
        private Vector3 DoorPositionCalculator(Building building)
        {
            // Init vars
            float centerX = (float)building.CenterX.Value;
            float centerY = (float)building.CenterY.Value;
            float angleInDegrees = (float)building.Rotation.Value;

            // convert to radians
            float angleInRadians = angleInDegrees * Mathf.Deg2Rad;

            // Calculate the door position in local space (front of the building)
            float centerXWithRotation = centerX - (centerX * Mathf.Cos(angleInRadians)
                - centerY * Mathf.Sin(angleInRadians));
            float centerYWithRotation = centerY - (centerX * Mathf.Sin(angleInRadians)
                + centerY * Mathf.Cos(angleInRadians));

            // Door X & Y No rotation
            float doorXNoRotation = centerX + (float)building.Length.Value / 2;
            float doorYNoRotation = centerY + (float)building.Width.Value / 2;

            // door final position
            float doorXPosition = doorXNoRotation * Mathf.Cos(angleInRadians)
                - doorYNoRotation * Mathf.Sin(angleInRadians) + centerXWithRotation;

            float doorYPosition = doorXNoRotation * Mathf.Sin(angleInRadians)
                + doorYNoRotation * Mathf.Cos(angleInRadians) + centerYWithRotation;

            return new Vector3(doorXPosition, 0, doorYPosition);

        }

        private void PlayerSpawn()
        {
            Vector3 playerPosition = _playerInstance.transform.position;
            playerPosition.x = BuildingSceneDataTransfer.Instance.BuildingAccessPointPosition.x;
            playerPosition.z = BuildingSceneDataTransfer.Instance.BuildingAccessPointPosition.z;
            Quaternion playerRotation = BuildingSceneDataTransfer.Instance.BuildingAccessPointRotation;

            // Fix rotation of the player
            // add 90 degrees in the y axis to the player rotation
            float yaw = playerRotation.eulerAngles.y + 270;
            Quaternion newRotation = Quaternion.Euler(playerRotation.eulerAngles.x, yaw, playerRotation.eulerAngles.z);

            // Apply the new position to the player instance
            _playerInstance.transform.position = playerPosition;
            _playerInstance.transform.rotation = newRotation;
            // multiply by * 2 the rotation to fix the player rotation
        }
    }
}