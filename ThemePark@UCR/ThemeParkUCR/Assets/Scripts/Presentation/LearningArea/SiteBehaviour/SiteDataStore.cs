using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteBehaviour
{
    public class SiteDataStore : MonoBehaviour
    {
        public static SiteDataStore Instance { get; private set; }

        public string CampusName { get; set; }
        public string SiteName { get; set; }

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
            CampusName = string.Empty;
            SiteName = string.Empty;
        }
    }
}
