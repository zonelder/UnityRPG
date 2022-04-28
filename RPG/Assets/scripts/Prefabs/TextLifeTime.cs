using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLifeTime : MonoBehaviour
{
   public  GameObject _camera;
   public GameObject targetUnit;
   private Vector3 offSet;


    public void SetTextCarrier(GameObject target,GameObject camera)
    {
        targetUnit = target;
        _camera = camera;
    }
    void Update()
    {
        offSet = -2 * _camera.transform.right - 0.7f * _camera.transform.up;
        gameObject.transform.rotation = _camera.transform.rotation;
        gameObject.transform.position = targetUnit.transform.position + offSet;
    }
}
