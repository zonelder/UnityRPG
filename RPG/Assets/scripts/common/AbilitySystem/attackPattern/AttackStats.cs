using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStats
{
    private float speedAmp = 1;
    private float attackSpeedAmp = 1;
    private float damageAmp = 1;
    public Cooldown duration = new Cooldown(1);

    public void SetAll(float dAmp,float sAmp,float asAmp,float time)
    {
        speedAmp = sAmp;
        attackSpeedAmp = asAmp;
        damageAmp = dAmp;
        duration.SetCooldown(time);
    }
    public float GetSpeedAmp() { return speedAmp; }
    public  void SetSpeedAmp(float value) { speedAmp = value; }

    public float GetDamageAmp() { return damageAmp; }
    public  void SetDamageAmp(float value) { damageAmp = value; }

    public float GetDuration() { return duration.GetCooldown(); }
    public void SetDuration(float value) { duration.SetCooldown(value); }


    public float GetImprovedDuration() { return duration.GetCooldown() / speedAmp;}
    public AttackStats()
    {

    }

}
