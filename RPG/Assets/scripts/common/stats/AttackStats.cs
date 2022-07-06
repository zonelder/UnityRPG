using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AttackStats
{
    public Multiplier DamageAmp;
    public Cooldown Duration;

    public AttackStats(float dAmp = 1, float duration = 1)
    {
        DamageAmp = new Multiplier(dAmp);
        Duration = new Cooldown(duration);
    }
    public void SetAll(float dAmp,float time)
    {
        DamageAmp.SetValue(dAmp);
        Duration.SetCooldown(time);
    }
}
