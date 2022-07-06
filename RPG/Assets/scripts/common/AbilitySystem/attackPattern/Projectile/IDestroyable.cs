using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyable
{
    public void Execute(Vector3 hitPoint,UnitEntity user);
}
