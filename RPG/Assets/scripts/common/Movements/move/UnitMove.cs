using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InfluenceMethods(ref Vector3 velocity);
public delegate void OnMoveMethod();

public abstract class UnitMove
{
    public abstract event InfluenceMethods ChangeMove;
    public abstract event OnMoveMethod OnMove;
    public abstract event OnMoveMethod OnStop;
    public bool IsMoveable { get; set; } = true;
    public abstract void Execute(Vector3 direction, Transform unitTransform);
}
