using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTouched : ITouchable
{
    public void Execute(GameObject touchedGameObject,UnitEntity user)
    {
        UnitEntity beatenEntity = touchedGameObject.GetComponent<UnitEntity>();
        //beatenEntity?.GetHit(user);
        if (beatenEntity != null) 
        user.DoneDamage(beatenEntity);
    }
}
