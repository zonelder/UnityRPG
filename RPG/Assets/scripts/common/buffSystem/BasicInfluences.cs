using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class BasicInfluences
{
       public static void ChangeDamage(GameObject unit, float minAdd,float maxAdd)
       {
        unit.GetComponent<UnitStats>()._improved.damage.maxDMG += minAdd;
        unit.GetComponent<UnitStats>()._improved.damage.minDMG += maxAdd;
        }
        public static void ChangeHP(GameObject unit,float extraHP)
        {

            unit.GetComponent<UnitStats>()._improved.HP += extraHP;
    }
}
