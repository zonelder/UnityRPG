using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearIgnoreUnitsAim : IAim
{
    public Vector3? Execute(Camera camera, float range)
    {
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit[] hits = Physics.RaycastAll(rayOrigin, camera.transform.forward, range);

        float minDist = float.MaxValue;
        Vector3 EndPoint = Vector3.zero;

        foreach (var hit in hits)
        {
            float dist = Vector3.Distance(hit.point, camera.transform.position);
            if (hit.collider.gameObject.GetComponent<UnitEntity>() == null && dist < minDist)
            {
                EndPoint = hit.point;
                minDist = dist;
            }

        }
        if (minDist == float.MaxValue)
        {
            EndPoint = rayOrigin + (camera.transform.forward * range);
        }
        return EndPoint;
    }
}
