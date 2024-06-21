using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class ProjectorBehaviour : Interactable
    {
        // Start is called before the first frame update
        [SerializeField]
        private GameObject _projector;
        public override void Interact()
        {
            base.Interact();
            if(_projector.GetComponent<Light>().enabled == false)
            {
                _projector.GetComponent<Light>().enabled = true;
            }
            else
            {
                _projector.GetComponent<Light>().enabled = false;
            }
        }

    }
}
