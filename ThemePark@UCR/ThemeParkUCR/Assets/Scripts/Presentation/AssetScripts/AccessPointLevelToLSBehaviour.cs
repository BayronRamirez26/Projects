using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.LevelBehaviour;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class AccessPointLevelToLSBehaviour : Interactable
    {

        [SerializeField]
        GameObject _learningSpaceData;

        public override void Interact()
        {
            base.Interact();

            // Set the LevelId in the global object to be used in the next scene
            var learningSpaceDataStore = _learningSpaceData?.GetComponent<LearningSpaceDataStore>();
            ViewLearningSpaceButton.learningSpaceGuid = learningSpaceDataStore.LeaningSpaceId;

            // Load LevelArea scene
            SceneManager.LoadScene("LearningSpace");
        }
    }
}
