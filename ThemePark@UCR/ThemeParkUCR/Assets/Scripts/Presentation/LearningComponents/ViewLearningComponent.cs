using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class ViewLearningComponent : MonoBehaviour
    {
        public TMP_Dropdown dropdown; // Referencia al TMP_Dropdown en el editor

        void Start()
        {
            // A�adir el listener al bot�n
            Button switchSceneButton = GetComponent<Button>();
            if (switchSceneButton != null)
            {
                switchSceneButton.onClick.AddListener(OnSwitchSceneButtonClicked);
            }
        }

        void OnSwitchSceneButtonClicked()
        {
            // Obtener la opci�n seleccionada en el TMP_Dropdown
            int selectedOption = dropdown.value;

            // Cambiar de escena basado en la opci�n seleccionada
            switch (selectedOption)
            {
                case 0:
                    SceneManager.LoadScene("Whiteboards"); // Pizarras
                    break;
                case 1:
                    SceneManager.LoadScene("Scene2"); // Proyectores
                    break;
                case 2:
                    SceneManager.LoadScene("Scene3"); // Nombre de la tercera escena
                    break;
            
                default:
                    Debug.LogError("Opci�n no v�lida");
                    break;
            }
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
