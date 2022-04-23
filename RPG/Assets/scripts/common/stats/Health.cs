using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health //class that no longer needed.but it ll be better to exchange current code to this one 
{
    float curHP;
    float maxHP;
    float HPAtrophy;
    float HPregen;

    public Health(float _maxHP)
    {
        maxHP = _maxHP;
        curHP = maxHP;
        HPAtrophy = 100.0f;//default;
        HPregen = 0.0f;
    }
    public Health(float _maxHP,float HPreg, float HPAtrophy)
    {
        maxHP = _maxHP;
        curHP = maxHP;
        this.HPAtrophy = HPAtrophy;
        HPregen = HPreg;
    }

    public void HealthTick(float deltaTime,LifeStates state)
    {
        curHP +=HPregen*deltaTime;
        if (curHP > maxHP)
            curHP = maxHP;
        if (state == LifeStates.MIND_ON_THE_EDGE)
        {
            curHP -= HPAtrophy * deltaTime;
        }
        if (curHP <= 0)
            curHP = 0;

    }

}
