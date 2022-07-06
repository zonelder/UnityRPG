using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    public void Execute(Projectile movingObj,Transform startTransform, UnitEntity unit); 
}
