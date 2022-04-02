using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStats
{
    private float speedAmp = 1;
    private float damageAmp = 1;
    public Cooldown BaseDuration = new Cooldown(1);
    public float initialSpeed;
    public float finalSpeed;
    private Vector3 shift = new Vector3(0, 0, 0);
    //private Shift shift;

    public void SetSpeed(float startSpeed,float endSpeed)
    {
        initialSpeed = startSpeed;
        finalSpeed = endSpeed;
    }
    public void RecalculateDuration()
    {
        float path = shift.magnitude;
        float avrVelocity= (finalSpeed+ initialSpeed)/2;//работает только если скорость изменяется линейно от начала до конца
        BaseDuration.SetCooldown(path / avrVelocity);
    }
    public float GetSpeedAmp() { return speedAmp; }
    public  void SetSpeedAmp(float value) { speedAmp = value; }

    public float GetDamageAmp() { return damageAmp; }
    public  void SetDamageAmp(float value) { damageAmp = value; }

    public float GetDuration() { return BaseDuration.GetCooldown(); }
    public void SetDuration(float value) { BaseDuration.SetCooldown(value); }

    public Vector3 GetShift() { return shift; }
    public void SetShift(Vector3 value) { shift = value; }

    public float GetImprovedDuration() { return BaseDuration.GetCooldown() / speedAmp;}
    public float VelocityAt(float time)
    {
        return ((finalSpeed - initialSpeed) / BaseDuration.GetCooldown() * time +initialSpeed)*speedAmp;//линейнай зависимость
    }
    public Vector3 VectorOfMove(GameObject unit)
    {
        return unit.transform.forward * shift.z + unit.transform.right * shift.x + unit.transform.up * shift.y;
    }
    public AttackStats()
    {

    }

}
