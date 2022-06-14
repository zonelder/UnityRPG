using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitRotation
{
    public abstract void DisableRotation();

    public abstract void EnableRotation();

    public abstract void Rotate(Vector3 lookTo,Transform playerTransform);
}
