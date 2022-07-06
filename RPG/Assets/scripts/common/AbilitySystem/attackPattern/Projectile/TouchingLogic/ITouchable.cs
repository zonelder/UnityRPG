using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable 
{
    public void Execute(GameObject touchedGameObject,UnitEntity user);
}
