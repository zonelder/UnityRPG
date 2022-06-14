using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AttackStats
{
    public Multiplier SpeedAmp;
    public Multiplier AttackSpeedAmp;
    public Multiplier DamageAmp;
    public Cooldown Duration;

    public AttackStats(float SAmp = 1, float ASAmp = 1, float dAmp = 1, float duration = 1)
    {
        SpeedAmp = new Multiplier(SAmp);
        AttackSpeedAmp = new Multiplier(ASAmp);
        DamageAmp = new Multiplier(dAmp);
        Duration = new Cooldown(duration);
    }
    public void SetAll(float dAmp,float sAmp,float asAmp,float time)
    {
        SpeedAmp.SetValue(sAmp);
        AttackSpeedAmp.SetValue(asAmp);
        DamageAmp.SetValue( dAmp);
        Duration.SetCooldown(time);
    }
}
