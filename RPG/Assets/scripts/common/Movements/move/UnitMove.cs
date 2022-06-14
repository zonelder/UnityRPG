using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MoveMethods(ref Vector3 velocity);
public abstract class UnitMove
{
    public abstract  event MoveMethods OnMove;
    public abstract void DisableMove();
    public abstract void EnableMove();
    public abstract bool IsMoveable { get; }
    public abstract void Move(Vector3 direction, Rigidbody unitRigit);
}
