using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.BuildingBehaviour;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.LevelBehaviour;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.Shared;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class AccessPointLevelToLevelUpBehaviour : Interactable
    {

        public override void Interact()
        {
            base.Interact();
            // get what level is the player in
            var currentLevelGuid = SceneLevelTransferObject.Instance.LevelKey;
     
            // set the LevelId in the global object to be used in the next scene
            // if the there are levels above the current level, load the next level
            // else do nothing
            var index = SceneLevelList.Instance.Levels.FindIndex(x => x.LevelId.Value == currentLevelGuid);
            if (index < SceneLevelList.Instance.Levels.Count - 1)
            {
                SceneLevelTransferObject.Instance.LevelKey = SceneLevelList.Instance.Levels[index + 1].LevelId.Value;
                // Load LevelArea scene
                SceneManager.LoadScene("LevelArea");
            }
            else
            {
                Debug.Log("No levels above the current level.");
            }

        }

    }
}
