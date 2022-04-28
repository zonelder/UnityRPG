using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class BasicInfluences
{
        public static void ChangeDamage(GameObject unit, float minAdd,float maxAdd)
        {
        unit.GetComponent<UnitStats>()._improved.damage.ChangeDamage(minAdd, maxAdd);
        }
        public static void ChangeHP(GameObject unit,float extraHP)
        {

            unit.GetComponent<UnitStats>()._improved.HP.AddToMax(extraHP);
        }
}
