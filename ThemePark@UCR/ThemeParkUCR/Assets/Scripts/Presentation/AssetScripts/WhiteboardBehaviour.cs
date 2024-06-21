using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class WhiteboardBehaviour : Interactable
    {
        // Start is called before the first frame update
        public GameObject marcadorPrefab;  // Referencia al prefab del marcador
        private GameObject marcadorActual;  // Referencia al marcador actualmente instanciado
        private bool marcadorAgarrado;
        public override void Interact()
        {


            base.Interact();
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Detectar si el rayo intersecta con un objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto clickeado es la pizarra
                if (hit.collider.gameObject == gameObject)
                {
                    // Obtener la posición donde se hizo clic
                    Vector3 clickPosition = new Vector3((float)0.0, (float)0.0, (float)0.0);

                    // Instanciar el marcador en la posición del clic
                    // Ajusta la rotación del objeto para que sea horizontal
                    Quaternion rotacionHorizontal = Quaternion.Euler(90, 0, 0);
                    marcadorActual = Instantiate(marcadorPrefab, clickPosition, rotacionHorizontal);


                    // Marcar el marcador como agarrado
                    marcadorAgarrado = true;
                }
            }
            // Liberar el marcador si se hace clic nuevamente en él
            if (Input.GetMouseButtonDown(0) && marcadorActual != null && marcadorAgarrado)
            {
              
                // Detectar si el rayo intersecta con un objeto
                if (Physics.Raycast(ray, out hit))
                {
                    // Verificar si el objeto clickeado es el marcador actual
                    if (hit.collider.gameObject == marcadorActual)
                    {
                        // Destruir el marcador
                        Destroy(marcadorActual);
                        marcadorAgarrado = false; // Marcar el marcador como no agarrado
                    }
                }
            }

            // Si el marcador está agarrado, seguir la posición del mouse
            if (marcadorAgarrado && marcadorActual != null)
            {
                // Calcular la posición donde se debe mover el marcador
                if (Physics.Raycast(ray, out hit))
                {
                    marcadorActual.transform.position = hit.point;
                }
            }
        }
    }
}


