using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Shift
{

    [HideInInspector] public bool AlreadyUsed=false;
    public Cooldown Duration;// ¬рем€ за которое будет пройдена траектори
    private float _startTime=0;

    public Curve3 trajectory;
    [SerializeField]  private Vector3 _scale;
    private Basis _startTransform;
    // ѕозици€ и направление, в котором началось перемещение
    public void SetStartTime(float time) { _startTime = time; }
    public float StartTime=>_startTime;
    public void SetStartTransform(Transform curUnitTransform)
    {
        _startTransform = new Basis(curUnitTransform);
    }
    public Vector3 CurLocalPosition()
    {
        return  LocalPositionAt(Duration.curTime() / Duration.GetCooldown());
    }
    public Vector3 CurPosition()
    {
        return PositionAt(Duration.curTime()/ Duration.GetCooldown());
    }
    public Vector3 PositionAt(float time)
    {
        
        return _startTransform.ConvertToWorldSpace(LocalPositionAt(time));
    }
    public Vector3 LocalPositionAt(float time)
    {
        Vector3 localPos = trajectory.Evaluate(time);
        localPos.Scale(_scale);
        return localPos;
    }
    public Vector3 Scale
    {
        get => _scale;
        set { _scale = value; }
    }
    public Vector3 GetKeyGlobalPosition(int index)=> PositionAt(trajectory.GetKeyTime(index));
    public Vector3 GetKeyLocalPosition(int index) => LocalPositionAt(trajectory.GetKeyTime(index));
    public int GetKeyLength()
    {
        return trajectory.Length;
    }


    public Shift()
    {
        _scale = Vector3.one;
        trajectory = Curve3.Constant(0, 1, 0);
        Duration = new Cooldown(1);
    }

}
