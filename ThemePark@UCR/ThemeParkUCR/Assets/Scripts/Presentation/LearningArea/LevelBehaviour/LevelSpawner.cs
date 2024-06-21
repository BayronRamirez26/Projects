using System;
using System.Collections.Generic;
using System.Linq;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Application.LearningArea.Services;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Events;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningSpace.Entities;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.Shared;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.LevelBehaviour
{
    public class LevelSpawner : MonoBehaviour
    {

        // Serialized fields are exposed in the Unity Editor
        [SerializeField]
        private GameObject _levelPrefab;

        [SerializeField]
        private GameObject _learningSpaceAccessPoint;

        [SerializeField]
        private GameObject _siteAccessPoint;

        [SerializeField]
        private GameObject _levelUpAccessPoint;

        [SerializeField]
        private GameObject _levelDownAccessPoint;

        [SerializeField]
        private GameObject _playerInstance;

        [SerializeField]
        private float _accessPointOffset;

        [Inject]
        private IEventChannel _eventChannel;

        [Inject]
        private IAccessPointService _learningSpaceAccessPointService; 

        // Used to store the current level game object
        private GameObject _currentLevelGameObject;


        // Start is called before the first frame update
        void Start()
        {
            _eventChannel.Subscribe<FetchLevelsFromBuldingEvent>(OnFetchLevelsFromBuldingEvent);
        }

        void OnDestroy()
        {
            _eventChannel.Unsubscribe<FetchLevelsFromBuldingEvent>(OnFetchLevelsFromBuldingEvent);
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        private void OnFetchLevelsFromBuldingEvent(FetchLevelsFromBuldingEvent @event)
        {
            // The levels are always enable in the LevelArea scene
            SceneLevelList.Instance.Levels = new List<Level>(@event.Levels);
            // If the level key is not set, load the first level
            if (SceneLevelTransferObject.Instance.LevelKey == Guid.Empty)
            {
                SceneLevelTransferObject.Instance.LevelKey = SceneLevelList.Instance.Levels[0].LevelId.Value;
            }
            // Charge global index to navigate between levels
            LoadLevel(SceneLevelTransferObject.Instance.LevelKey);
        }

        private void LoadLevel(Guid levelKey)
        {
            // load the level with the same key
            var level = SceneLevelList.Instance.Levels.FirstOrDefault(l => l.LevelId.Value == levelKey);
            // Adjust position if necessary
            var levelPosition = transform.position;
            _currentLevelGameObject = Instantiate(_levelPrefab, levelPosition, transform.rotation);

            // Load the level data  
            var levelPresenter = _currentLevelGameObject.GetComponent<LevelPresenter>();
            levelPresenter.OnLoad(level);

            // Load the access points
            // Place the learning space access points in the level
            PlaceLearningSpaceAccessPoints(level);

            // if there are more than one level, place access points between levels
            if (SceneLevelList.Instance.Levels.Count > 1)
            {
                PlaceAccessPointBetweenLevels(level);
            }

            // if this is the level 1, place access point to site
            if (level.LevelId == SceneLevelList.Instance.Levels.First().LevelId)
            {
                // Place the access point to the site
                PlaceAccessPointToSite(level);
            }

            // If it is the first time the level is loaded, place the player in the site access point
            if (SceneLevelTransferObject.Instance.FirstTimeEntering)
            {
                PlayerSpawnSiteAccessPoint(level);
                SceneLevelTransferObject.Instance.FirstTimeEntering = false;
            } 
            else
            {
                // If it is not the first time the level is loaded, place the player in the level access point
                PlayerSpawnLevelAccessPoint(level);
            }
        }


        private async void PlaceLearningSpaceAccessPoints(Level level)
        {
            // Call the get access point service
            var learningSpaceAccessPoints = await _learningSpaceAccessPointService.GetAccessPointsFromLevelAsync(level.LevelId.Value);
            
            // Define the dimensions of the level
            float levelWidth = (float)level.SizeX.Value;
            float levelLength = (float)level.SizeY.Value;

            // Calculate positions for the left and right walls
            float leftWallX = -levelWidth / 2;
            float rightWallX = levelWidth / 2;

            // Calculate the spacing between access points
            int totalAccessPoints = learningSpaceAccessPoints.Count();
            float spacing = levelLength / (totalAccessPoints / 2);

            // Place the doors of the access points in the level left and right walls
            float currentOffsetBetweenAccessPoints = 0;
            for (int i = 0; i < totalAccessPoints; i++)
            {
                Vector3 position;
                Quaternion rotation = Quaternion.Euler(0, 0, 0); // Default rotation

                if (i % 2 == 0) // Place on left wall
                {
                    position = new Vector3(leftWallX, 0, currentOffsetBetweenAccessPoints);
                }
                else // Place on right wall
                {
                    position = new Vector3(rightWallX, 0, currentOffsetBetweenAccessPoints);
                }

                // Instantiate the access point at the calculated position and rotation
                var accessPoint = learningSpaceAccessPoints.ElementAt(i);
                var learningSpaceAccessPointGO = Instantiate(_learningSpaceAccessPoint, position, rotation);
                SetDataToLearningSpaceAccessPoint(learningSpaceAccessPointGO, accessPoint);

                currentOffsetBetweenAccessPoints += _accessPointOffset; 
            }
        }

        private void SetDataToLearningSpaceAccessPoint(GameObject learningSpaceAccessPoint, AccessPoint accessPoint)
        {
            var learningSpaceDataStore = learningSpaceAccessPoint.transform.Find("LearningSpaceData").GetComponent<LearningSpaceDataStore>();
            learningSpaceDataStore.LeaningSpaceId = accessPoint.LearningSpaceId.Value;
        }

        private void PlaceAccessPointBetweenLevels(Level level)
        {
            // adjust rotation of the access points, because the front wall is rotated 90 degrees
            var accessPointRotation = Quaternion.Euler(0, 90, 0);
            var frontWallPosition = -(float)level.SizeY.Value / 2;

            // if is the first level, only spawn one access point with next level behaviour
            if (level.LevelId == SceneLevelList.Instance.Levels.First().LevelId)
            {
                // set the position of the access point, in the same postion of the front wall of the level
                var accessPointPosition = new Vector3(0, 0, frontWallPosition);
                // instantiate the access point
                Instantiate(_levelUpAccessPoint, accessPointPosition, accessPointRotation);
            }
            else
            {
                // if is the last level, only spawn one access point with previous level behaviour
                if (level.LevelId == SceneLevelList.Instance.Levels.Last().LevelId)
                {
                    var accessPointPosition = new Vector3(0, 0, frontWallPosition);
                    Instantiate(_levelDownAccessPoint, accessPointPosition, accessPointRotation);
                }
                else
                {
                    // if is a level in the middle, spawn two access points with next and previous level behaviour
                    // one next to the other in the same front wall of the level

                    // Calculate positions for the access points
                    var upAccessPointPosition = new Vector3(-_accessPointOffset, 0, frontWallPosition);
                    var downAccessPointPosition = new Vector3(_accessPointOffset, 0, frontWallPosition);

                    // Instantiate the access points at the calculated positions
                    Instantiate(_levelUpAccessPoint, upAccessPointPosition, accessPointRotation);
                    Instantiate(_levelDownAccessPoint, downAccessPointPosition, accessPointRotation);
                }
            }
        }

        private void PlaceAccessPointToSite(Level level)
        {
            // set the position of the access point, in the same postion of the front wall of the level
            // instantiate the access point
            // put the site door in the back wall of the level
            Instantiate(
                _siteAccessPoint, 
                new Vector3(0, 0, (float)level.SizeY.Value / 2), 
                Quaternion.Euler(0, 90, 0)
            );
        }

        private void PlayerSpawnSiteAccessPoint(Level level)
        {
            // Set the new position based on the site access point position
            Vector3 playerPosition = _playerInstance.transform.position;
            playerPosition.z = ((float)level.SizeY.Value / 2) - 2;
            // Fix rotation 180 degrees
            _playerInstance.transform.rotation = Quaternion.Euler(0, 180, 0);

            // Apply the new position to the player instance
            _playerInstance.transform.position = playerPosition;
        }

        private void PlayerSpawnLevelAccessPoint(Level level)
        {
            // Set the new position based on the level access point position
            Vector3 playerPosition = _playerInstance.transform.position;
            playerPosition.z = -((float)level.SizeY.Value / 2) + 2;
            // Fix rotation 0 degrees
            _playerInstance.transform.rotation = Quaternion.Euler(0, 0, 0);

            // Apply the new position to the player instance
            _playerInstance.transform.position = playerPosition;
        }
    }
}
