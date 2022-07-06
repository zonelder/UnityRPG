using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAim : IAim
{
    public Vector3? Execute(Camera camera,float range)
    {
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        Vector3 EndPoint = Vector3.zero;

        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, range))
        {
            EndPoint = hit.point;
        }
        else
        {
            EndPoint = rayOrigin + (camera.transform.forward * range);
        }
        return EndPoint;
    }
}
