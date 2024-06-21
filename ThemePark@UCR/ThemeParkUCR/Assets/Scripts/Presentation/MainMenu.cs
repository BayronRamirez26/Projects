using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class MainMenu : MonoBehaviour
    {
        public void ListLearningSpace()
        {
            SceneManager.LoadScene("ChooseLearningSpace");
            // alternative implementation is using the active scene counter, but it is not recommended because scene
            // order can change and it is not a good practice to rely on that
        }

        public void ListLearningComponent()
        {
            SceneManager.LoadScene("ChooseLearningComponent");
            // alternative implementation is using the active scene counter, but it is not recommended because scene
            // order can change and it is not a good practice to rely on that
        }

        public void LoadSiteWithBuildings()
        {
            SceneManager.LoadScene("ChooseLearningArea");
        }

        // TODO: implement method for other placeholders-buttons
        public void AccessLearningSpace()
        {
            SceneManager.LoadScene("Default LearningSpace");
        }

        public void Exit()
        {
            //Application.Quit();
            //Debug.Log("Exit button pressed!");
        }

    }
}