using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    

        public class StateManager : MonoBehaviour
        {
            public MovementValues movementValues;
            public Inventory inventory;

        /*
            public StatesVariable targetVariable;
            private void OnEnable()
            {
                targetVariable.value = GetComponent<StateManager>();
            }*/

        

            [System.Serializable]
            public class MovementValues
            {
                public float horizontal;
                public float vertical;
                public float moveAmount;
                public Vector3 moveDirection;
                public Vector3 lookDirection;
                public Vector3 aimPosition;
            }

            

            public bool isAiming;
            public bool isShooting;
            public bool isInteracting;
            public bool isCrouching;

        public bool isJumping;    

            public void SetCrouching()
        {
            isCrouching = !isCrouching;
        }

            
            public State currentState;

            [HideInInspector]
            public Animator anim;

            [HideInInspector]
            public float delta;
            [HideInInspector]
            public Transform mTransform;
            [HideInInspector]
            public Rigidbody rigid;
            [HideInInspector]
            public LayerMask ignoreLayers;
            [HideInInspector]
            public AnimatorHook animHook;

            public StateActions initActionsBatch;
        

        private void Start()
            {
                //Physics.gravity = new Vector3(0, -10.0F, 0);
                mTransform = this.transform;
                rigid = GetComponent<Rigidbody>();
                rigid.drag = 1;
                rigid.angularDrag = 0.05f;
                rigid.constraints = RigidbodyConstraints.FreezeRotation;
                ignoreLayers = ~(1 << 8 | 1 << 3);

                anim = GetComponentInChildren<Animator>();

                initActionsBatch.Execute(this);
            }

            private void FixedUpdate()
            {

            delta = Time.deltaTime;
                if (currentState != null)
                {
                    currentState.FixedTick(this);
                }
            }

            private void Update()
            {
                if (currentState != null)
                {
                    currentState.Tick(this);
                }
            }
        }
    
}
