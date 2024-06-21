using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour
{

    /// <summary>
    /// Always when a level scene is loaded, this class will be responsible for transferring the data from the building to the scene.
    /// And any other scene that needs to know the building data will be able to access it.
    /// </summary>
    public class BuildingSceneDataTransfer : MonoBehaviour
    {
        public static BuildingSceneDataTransfer Instance { get; private set; }

        public string UniversityName { get; set; }
        public string CampusName { get; set; }
        public string SiteName { get; set; }
        public string BuildingAcronym { get; set; }
        public Vector3 BuildingAccessPointPosition { get; set; }
        public Quaternion BuildingAccessPointRotation { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Resets all data properties to their default values.
        /// </summary>
        public void ResetData()
        {
            UniversityName = string.Empty;
            CampusName = string.Empty;
            SiteName = string.Empty;
            BuildingAcronym = string.Empty;
        }
    }
}
