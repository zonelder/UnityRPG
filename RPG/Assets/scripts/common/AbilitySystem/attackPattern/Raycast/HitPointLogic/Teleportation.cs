using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : IHit
{
    public Teleportation() { }
    public void Execute(Vector3 hitPoint, UnitEntity user)
    {
        user.StartCoroutine(TeleportationByTime(hitPoint, user));
    }

    private IEnumerator TeleportationByTime(Vector3 TeleportPoint,UnitEntity unit)
    {
        float speed = 100;
        Vector3 target = TeleportPoint + Vector3.up;
        unit.GoBodiless();
        while (unit.transform.position!=target)
        {
            unit.transform.position=Vector3.MoveTowards(unit.transform.position,target,speed*Time.deltaTime);
            yield return null;
        }
        unit.GoBodily();
    }
}
