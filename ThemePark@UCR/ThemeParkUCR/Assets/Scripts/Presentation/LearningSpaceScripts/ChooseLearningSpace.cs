using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class ChooseLearningSpace : MonoBehaviour
    {

        void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

           
        }

        // Start is called before the first frame update
        public void CreateLearningSpace()
        {
            SceneManager.LoadScene("LearningSpace");
            // alternative implementation is using the active scene counter, but it is not recommended because scene
            // order can change and it is not a good practice to rely on that
        }


        public void GoBackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        // TODO: implement method for other placeholders-buttons

        public void Exit()
        {
            //Application.Quit();
            //Debug.Log("Exit button pressed!");
        }

    }
}
