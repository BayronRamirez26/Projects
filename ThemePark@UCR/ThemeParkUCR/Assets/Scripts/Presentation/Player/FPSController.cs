using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{

    [RequireComponent(typeof(CharacterController))]
    public class FPSController : MonoBehaviour
    {

        public Camera playerCamera;
        public float walkSpeed = 6.0f;
        public float runSpeed = 10.0f;
        public float jumpPower = 7.0f;
        public float gravity = 10.0f;

        public float lookSpeed = 2.0f;
        public float lookXLimit = 45.0f;

        Vector3 moveDirection = Vector3.zero;
        float rotationX = 0;

        public bool canMove = true;

        CharacterController characterController;


        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();

            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        // Update is called once per frame
        void Update()
        {
            #region Handles Movment
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            #endregion

            #region Handles Rotation
            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
            #endregion
        }
    }
}
