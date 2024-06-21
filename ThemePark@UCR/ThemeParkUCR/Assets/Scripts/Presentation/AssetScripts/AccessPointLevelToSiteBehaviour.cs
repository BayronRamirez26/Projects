using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.LevelBehaviour;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.Shared;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class AccessPointLevelToSiteBehaviour : Interactable
    {

        public override void Interact()
        {
            base.Interact();

            // clear building data before loading the SiteArea scene
            BuildingSceneDataTransfer.Instance.ResetData();
            SceneLevelTransferObject.Instance.ResetData();
            SceneLevelList.Instance.ResetData();

            // Load LevelArea scene
            SceneManager.LoadScene("SiteArea");
        }
    }
}
