using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryMove : IMoveable
{
    public Shift Trajectory;
    public TrajectoryMove()
    {
        Trajectory = new Shift();
    }
    public void Execute(Projectile movingObj,Transform startTransform, UnitEntity unit)
    {
        Trajectory.SetStartTransform(startTransform);

        unit.StartCoroutine(TrajectoryByTime(movingObj, unit));
    }

    private IEnumerator TrajectoryByTime(Projectile movingObj,UnitEntity unit)
    {

        Trajectory.Duration.Start—ountdown();
        while(!Trajectory.Duration.IsReady)
        {
            Trajectory.Duration.TickTime(Time.deltaTime);
            movingObj.transform.position= Trajectory.CurPosition();
            yield return null;
        }
    }
}
