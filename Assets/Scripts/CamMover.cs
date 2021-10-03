using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamMover : MonoBehaviour
{
    public int state = 0;

    public Transform[] positions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard.aKey.wasPressedThisFrame && state > 0)
        {
            state--;
        }

        if (keyboard.dKey.wasPressedThisFrame && state < 1)
        {
            state++;
        }

        transform.position = positions[state].position;
    }
}
