using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRotation :UnitRotation
{
    private bool _canRotate=true;
    public override void DisableRotation() => _canRotate=false;
    public override void EnableRotation() => _canRotate = true;

    public override void Rotate(Vector3 lookTo, Transform unitTransform)
    {
        if (lookTo != Vector3.zero && _canRotate)
        {
            unitTransform.forward = lookTo;
        }
    }
}
