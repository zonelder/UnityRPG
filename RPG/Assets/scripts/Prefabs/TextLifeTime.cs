using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLifeTime : MonoBehaviour
{
   public  GameObject camera;
   public GameObject targetUnit;
    private Vector3 offSet;
    void Update()
    {
        offSet = -2 * camera.transform.right - 0.7f * camera.transform.up;
        gameObject.transform.rotation = camera.transform.rotation;
        gameObject.transform.position = targetUnit.transform.position + offSet;
    }
}
