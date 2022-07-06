using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Curve3
{
    [SerializeField]
    private AnimationCurve x;
    [SerializeField]
    private AnimationCurve y;
    [SerializeField]
    private AnimationCurve z;
    public int Length
    {
        get
        {
            if (IsLengthEqual())
                return x.length;
            else
                throw new System.Exception("number of keys not synchronized.Curve currupted");
        }
    }
    public Vector3 Evaluate(float time) => new Vector3(x.Evaluate(time), y.Evaluate(time), z.Evaluate(time));
    public void AddKey(float time,float x,float y,float z)
    {
        this.x.AddKey(time, x);
        this.y.AddKey(time, y);
        this.y.AddKey(time, z);
    }
    public void MoveKey(int index,float time ,Vector3 point)
    {
        x.RemoveKey(index);
        x.AddKey(time, point.x);

        y.RemoveKey(index);
        y.AddKey(time, point.y);

        z.RemoveKey(index);
        z.AddKey(time, point.z);

    }
    public void RemoveKey(int index)
    {
        x.RemoveKey(index);
        y.RemoveKey(index);
        z.RemoveKey(index);
    }
    public Vector3 GetKeyPosition(int index)=> new Vector3(x[index].value, y[index].value, z[index].value);
    public float GetKeyTime(int index)
    {
        if (IsKeyTimeEqual(index))
            return x[index].time;
        else
            throw new System.Exception("key time currupted");
    }
    public Curve3(AnimationCurve x,AnimationCurve y,AnimationCurve z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static Curve3 Constant(float timeStart,float timeEnd,float value)
    {
        return new Curve3(AnimationCurve.Constant(timeStart, timeEnd, value),
                          AnimationCurve.Constant(timeStart, timeEnd, value),
                          AnimationCurve.Constant(timeStart, timeEnd, value));
    }
    private bool IsKeyTimeEqual(int index) => x[index].time == y[index].time && y[index].time == z[index].time;
    private bool IsLengthEqual() => x.length == y.length && y.length == z.length;
}
