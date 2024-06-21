using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteBehaviour
{
    public class PlayerSpawner : MonoBehaviour
    {

        public void SpawnOnSiteArea()
        {
            // if dropdowns are not empty
            if (!string.IsNullOrEmpty(SiteDataStore.Instance.CampusName) &&
                !string.IsNullOrEmpty(SiteDataStore.Instance.SiteName))
            {
                SceneManager.LoadScene("SiteArea");
            }
        }
    }
}
