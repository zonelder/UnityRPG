using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WalkMove : UnitMove
{
    private bool _canMove=true;
    public override event MoveMethods OnMove;
    public override void DisableMove() => _canMove = false;
    public override void EnableMove() => _canMove = true;
    public override bool IsMoveable => _canMove;
    public override  void Move(Vector3 speedVector,Rigidbody unitRigit)
    {
        if (speedVector == Vector3.zero)
        {
            return;
        }
        OnMove?.Invoke(ref speedVector);
        unitRigit.velocity = speedVector;

    }
}
