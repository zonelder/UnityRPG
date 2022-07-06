using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class BasicInfluences
{
        public static void ChangeDamage(GameObject unit, float minAdd,float maxAdd)
        {
        unit.GetComponent<UnitEntity>().Improved.Damage.ChangeDamage(minAdd, maxAdd);
        }
        public static void ChangeHP(GameObject unit,float extraHP)
        {

            unit.GetComponent<UnitEntity>().Improved.HP.AddToMax(extraHP);
        }
}
