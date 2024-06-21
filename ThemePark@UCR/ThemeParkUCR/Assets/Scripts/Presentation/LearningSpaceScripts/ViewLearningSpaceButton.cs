using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class ViewLearningSpaceButton : MonoBehaviour
    {
        public static Guid learningSpaceGuid;
        // Start is called before the first frame update
        public void createLearningSpace()
        {
                SceneManager.LoadScene("LearningSpace");
            
        }

        public void updateValue(Guid guid)
        {
            learningSpaceGuid = guid;
            Debug.Log("Selected Learning Space ID: " + learningSpaceGuid);
        }
    }
}
