using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class Interactable : MonoBehaviour
    {

        //Outline outline;
        public string message;

        public virtual void  Interact()
        {
        }
    }
}