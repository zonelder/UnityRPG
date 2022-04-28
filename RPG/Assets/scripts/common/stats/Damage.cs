using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public float minDMG=0;
    public float maxDMG=0;
    public float critChanсe = 30.0f;// значение между 0 и 100;
    public float critDamage = 1.5f;//значение больше одного (если critDamage=1.5 а нанесли мы 100 урона то при крите будет 150)
    public void  ChangeDamage(float d_min,float d_max)
    {
        minDMG += d_min;
        maxDMG += d_max;
    }
    public GeneratedDamage calculate()
    {
        float curDamage = 0;
        DamageType type = DamageType.common;
        curDamage = Random.Range(minDMG, maxDMG);
        if (Random.Range(0.0f, 100.0f) <= critChanсe)
        {
            type = DamageType.crit;
            curDamage *= critDamage;
        }
        return  new GeneratedDamage(curDamage,type);
    }

}
