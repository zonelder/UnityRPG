using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMove : UnitMove
{
    public override event InfluenceMethods ChangeMove;
    public override event OnMoveMethod OnMove;
    public override event OnMoveMethod OnStop;
    public override  void Execute(Vector3 speedVector,Transform unitTransform)
    {
        if(IsMoveable)
        {
            if (speedVector == Vector3.zero)
            {
                OnStop?.Invoke();
                return;
            }
            ChangeMove?.Invoke(ref speedVector);
            unitTransform.position += speedVector*Time.fixedDeltaTime;
            OnMove?.Invoke();

        }
    }
}
