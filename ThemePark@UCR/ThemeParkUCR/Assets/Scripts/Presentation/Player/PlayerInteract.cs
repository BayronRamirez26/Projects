using TMPro;
using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI interactText;

        public float playerReach = 6f;
        Interactable currentInteractable;

        // Update is called once per frame
        void Update()
        {
            CheckInteraction();
            if (Input.GetKeyDown(KeyCode.Mouse0) && currentInteractable != null)
            {
                Debug.Log("Attempting to interact with: " + currentInteractable.gameObject.name);
                currentInteractable.Interact();
            }
        } 

        void CheckInteraction()
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            if (Physics.Raycast(ray, out hit, playerReach))
            {
                if(hit.collider.tag == "Interactable")
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    // Check if the object hit is an interactable object and not just any 3d object
                    if (interactable != null)
                    {
                        // set the transparency of the interactText to 0
                        Color color = interactText.color;
                        color.a = 1; // alpha value of 1 means the text is fully visible
                        interactText.color = color;

                        if (currentInteractable != null)
                        {
                        
                        
                            //currentInteractable.DisableOutline();
                        }
                        HUDController.instance.EnableInteractionText(interactable.message);
                        currentInteractable = interactable;
                        //currentInteractable.EnableOutline();
                        Debug.Log("Current interactable: " + currentInteractable.gameObject.name);
                    }
                    
                }else{
                    HUDController.instance.DisableInteractionText();
                    if (currentInteractable != null)
                    {
                        //currentInteractable.DisableOutline();
                        currentInteractable = null;


                    }
                }
                
            }
            else
            {
                // set the transparency of the interactText to 1
                Color color = interactText.color;
                color.a = 0; // alpha value of 0 means the text is invisible
                interactText.color = color;

                HUDController.instance.DisableInteractionText();
                if (currentInteractable != null)
                {
                    //currentInteractable.DisableOutline();
                    currentInteractable = null;
                }
            }
        }
    }
}
