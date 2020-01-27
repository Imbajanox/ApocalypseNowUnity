using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    
    public class OnEnableAssignStateManager : MonoBehaviour
    {
        public StatesVariable targetVariable;
        /*public void Awake()
        {
            targetVariable.value = GetComponent<StateManager>();
        }
        
        public void Update()
            {
                if(targetVariable == null)
                targetVariable.value = GetComponent<StateManager>();
            }*/

        private void OnEnable()
        {
            Debug.Log("OnEnableAssign StateManager assigned");
            targetVariable.value = GetComponent<StateManager>();
            Destroy(this);
        }
        /*
        public void Assign()
        {
            targetVariable.value = GetComponent<StateManager>();
            Destroy(this);
        }*/
    }
}
