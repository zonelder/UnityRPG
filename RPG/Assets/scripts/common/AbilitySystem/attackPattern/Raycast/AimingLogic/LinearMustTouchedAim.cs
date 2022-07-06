using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMustTouchedAim :IAim
{
    public Vector3? Execute(Camera camera, float range)
    {
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;
        Vector3? EndPoint;
        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, range))
        {
            EndPoint = hit.point;
        }
        else
        {
            EndPoint = null;
        }
        return EndPoint;
    }
}
