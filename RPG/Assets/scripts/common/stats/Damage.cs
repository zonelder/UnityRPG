using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public float minDMG=0; //Минимальный наносимый урон(Высчитывается по формуле)
    public float maxDMG=0; //Максимальный наносимый урон (Высчитывается по формуле)
    public float critChanсe = 30.0f;// значение между 0 и 100;
    public float critDamage = 1.5f;//значение больше одного (если critDamage=1.5 а нанесли мы 100 урона то при крите будет 150)
    public void  ChangeDamage(float d_min,float d_max)
    {
        minDMG += d_min;
        maxDMG += d_max;
    }
    public float calculate()//кажется что это будет считаться где то выше с учетом атрибутов атаки
    {
        float curDamage = 0;

        curDamage = Random.Range(minDMG, maxDMG);//возвращает случайное число от minDMG до maxDMG
        if (Random.Range(0.0f, 100.0f) <= critChanсe)//если прошел крит
        {
            curDamage *= critDamage;
        }
        return curDamage;
    }

}
