using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowPath : IHit
{
    private float _radius;

    public BlowPath(float radius)
    {
        _radius = radius;
    }

    public void Execute(Vector3 hitPoint, UnitEntity unit)
    {
        Collider[] colliders = Physics.OverlapCapsule(hitPoint,unit.transform.Find("weapon").transform.position, _radius);
        foreach (Collider nearbyCollider in colliders)
        {
            UnitEntity enemy = nearbyCollider.gameObject.GetComponent<UnitEntity>();
            //enemy?.GetHit(unit);
            if (enemy != null)
                unit.DoneDamage(enemy);
        }
    }
}
