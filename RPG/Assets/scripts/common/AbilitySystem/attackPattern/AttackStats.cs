using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStats
{
    private float speedAnim = 1;
    private float damageAmp = 1;
    private float duration = 1;
    public float speed;
    private Vector3 shift = new Vector3(0, 0, 0);

    
    public float GetSpeed() { return speedAnim; }
    public  void SetSpeed(float value) { speedAnim = value; }

    public float GetDamageAmp() { return damageAmp; }
    public  void SetDamageAmp(float value) { damageAmp = value; }

    public float GetDuration() { return duration; }
    public void SetDuration(float value) { duration = value; }

    public Vector3 GetShift() { return shift; }
    public void SetShift(Vector3 value) { shift = value; }
    public AttackStats()
    {

    }

}
