using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Shift
{
    public bool AlreadyUsed=false;
    private float _startTime=0;//время от начала каста атаки когда надо начать перемещаться

    [SerializeField]
    private AnimationCurve _forwardMove;
    [SerializeField]
    private float _forwardLength;

    [SerializeField]
    private AnimationCurve _rightMove;
    [SerializeField]
    private float _rightLength;

    [SerializeField]
    private AnimationCurve _upMove;
    [SerializeField]
    private float _upLength;
    public Cooldown Duration=new Cooldown(1);//расчитывается как время за которое будет пройден вектор shift и не может быть изменен извне
    private Vector3 _startPosition;
    private Vector3 _forwardDirection;
    private Vector3 _rightDirection;
    private Vector3 _upDirection;
    public void SetStartTime(float time) { _startTime = time; }
    public float StartTime() { return _startTime; }
   public void SetStartTransform(Transform curUnitTransform)
    {
        _startPosition = curUnitTransform.position;
        _forwardDirection = curUnitTransform.forward;
        _rightDirection = curUnitTransform.right;
        _upDirection = curUnitTransform.up;
    }

    public Vector3 CurPosition()
    {
        return PositionAt(Duration.curTime()/ Duration.GetCooldown());
    }
    public Vector3 PositionAt(float time)
    {
        return _startPosition+_forwardDirection * _forwardMove.Evaluate(time)*_forwardLength 
                             +_rightDirection* _rightMove.Evaluate(time)*_rightLength
                             + _upDirection * _upMove.Evaluate(time)*_upLength;
    }

    public Vector3 GetLenghts()
    {
        return new Vector3(_rightLength, _upLength, _forwardLength);
    }

    public Shift() { }

}
