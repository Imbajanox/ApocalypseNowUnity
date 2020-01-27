using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    private bool keyWasPressed = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Menu") > 0f)
        {
            if (!keyWasPressed)
                GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;

            keyWasPressed = true;
        }
        else
            keyWasPressed = false;
    }
}
