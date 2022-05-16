using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class BasicInfluences
{
        public static void ChangeDamage(GameObject unit, float minAdd,float maxAdd)
        {
        unit.GetComponent<UnitStats>().Improved.damage.ChangeDamage(minAdd, maxAdd);
        }
        public static void ChangeHP(GameObject unit,float extraHP)
        {

            unit.GetComponent<UnitStats>().Improved.HP.AddToMax(extraHP);
        }
}
