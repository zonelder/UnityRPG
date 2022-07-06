using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public bool Use;//если персонаж взаимодействует с чем-то
    [SerializeField] private movement _movement;

    private void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float perpedicular = Input.GetAxis("Horizontal");
        _movement.Move(new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")));
    }
    private void Update()
    {
        Use = false;
        if (Input.GetKey(KeyCode.R))
        {
            Use = true;
        }
    }
}
