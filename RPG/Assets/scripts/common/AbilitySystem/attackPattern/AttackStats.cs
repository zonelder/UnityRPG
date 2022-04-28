using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStats
{
    public Multiplier speedAmp;
    public Multiplier attackSpeedAmp;
    public Multiplier damageAmp;
    public Cooldown duration;

    public AttackStats(float SAmp = 1, float ASAmp = 1, float dAmp = 1, float duration = 1)
    {
        speedAmp = new Multiplier(SAmp);
        attackSpeedAmp = new Multiplier(ASAmp);
        damageAmp = new Multiplier(dAmp);
        this.duration = new Cooldown(duration);
    }
    public void SetAll(float dAmp,float sAmp,float asAmp,float time)
    {
        speedAmp.value = sAmp;
        attackSpeedAmp.value = asAmp;
        damageAmp.value = dAmp;
        duration.SetCooldown(time);
    }


}
