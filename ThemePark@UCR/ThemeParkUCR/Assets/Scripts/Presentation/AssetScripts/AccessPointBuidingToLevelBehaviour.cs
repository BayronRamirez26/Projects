using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class AccessPointBuidingToLevelBehaviour : Interactable
    {

        [SerializeField]
        GameObject _buildingData;

        public override void Interact()
        {
            base.Interact();
            ChargeSceneBuildingData();
            // if BuildingSceneDataTransfer data is not empty
            if (!string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.UniversityName) &&
                !string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.CampusName) &&
                !string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.SiteName) &&
                !string.IsNullOrEmpty(BuildingSceneDataTransfer.Instance.BuildingAcronym))
            {
                // Load LevelArea scene
                SceneManager.LoadScene("LevelArea");
            }
        }

        private void ChargeSceneBuildingData()
        {
            // get the data from the building
            var buildingDataStore = _buildingData?.GetComponent<BuildingDataStore>();
            BuildingSceneDataTransfer.Instance.UniversityName = buildingDataStore.UniversityName;
            BuildingSceneDataTransfer.Instance.CampusName = buildingDataStore.CampusName;
            BuildingSceneDataTransfer.Instance.SiteName = buildingDataStore.SiteName;
            BuildingSceneDataTransfer.Instance.BuildingAcronym = buildingDataStore.BuildingAcronym;
            BuildingSceneDataTransfer.Instance.BuildingAccessPointPosition = transform.position;
            BuildingSceneDataTransfer.Instance.BuildingAccessPointRotation = transform.rotation;
        }
    }
}
