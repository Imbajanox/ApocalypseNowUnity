using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Inputs/Input Manager")]
    public class InputManager : Action
    {
        public InputAxis horizontal;
        public InputAxis vertical;
        public InputButton aimInput;
        public InputButton shootInput;
        public InputButton crouchInput;
        public InputButton jumpInput;

        public float moveAmount;
        public Vector3 moveDirection;

        public SO.TransformVariable cameraTransform;
        public SO.TransformVariable pivotTransform;

        public StatesVariable playerStates;

        public bool debugAim;

        public override void Execute()
        {
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal.value) + Math.Abs(vertical.value));

            if (cameraTransform.value != null)
            {
                moveDirection = cameraTransform.value.forward * vertical.value;
                moveDirection += cameraTransform.value.right * horizontal.value;
                moveDirection.Normalize();
            }

            if (playerStates.value != null)
            {
                Debug.Log("Alles funktioniert");
                playerStates.value.movementValues.horizontal = horizontal.value;
                playerStates.value.movementValues.vertical = vertical.value;
                playerStates.value.movementValues.moveAmount = moveAmount;
                playerStates.value.movementValues.moveDirection = moveDirection;
                playerStates.value.isShooting = shootInput.isPressed;

                playerStates.value.isJumping = jumpInput;
                


                if (crouchInput.isPressed)
                {
                    playerStates.value.SetCrouching();
                    crouchInput.targetBoolVariable.value = playerStates.value.isCrouching;
                }

                if (!debugAim)
                    playerStates.value.isAiming = aimInput.isPressed;
                else
                {
                    playerStates.value.isAiming = true;
                    aimInput.isPressed = true;
                }

                playerStates.value.movementValues.lookDirection = cameraTransform.value.forward;

                Ray ray = new Ray(pivotTransform.value.position, pivotTransform.value.forward);
                playerStates.value.movementValues.aimPosition = ray.GetPoint(100);
            }
            else
            Debug.Log("playerStates.value == null");

        }
    }
}
