using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class LearningSpaceListMenu : MonoBehaviour
    {
        public void LearningSpace()
        {
            SceneManager.LoadScene("LearningSpace");
            // alternative implementation is using the active scene counter, but it is not recommended because scene
            // order can change and it is not a good practice to rely on that
        }

        // TODO: implement method for other placeholders-buttons

        public void Exit()
        {
            //Application.Quit();
            //Debug.Log("Exit button pressed!");
        }

    }
}